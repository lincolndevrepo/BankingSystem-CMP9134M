using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Common.Utilities;
using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;

namespace BankingSystem.DataAccess.Sql.Repository.Services
{
    public class RepoAccounts : IRepoAccounts
    {
        #region Declarations
        private readonly DapperContext Context;
        private SessionUserInfo sessionUserInfo = new SessionUserInfo();
        private AppSettingsSelect appSettings = new AppSettingsSelect();
        #endregion

        public RepoAccounts(DapperContext context)
        {
            Context = context;
        }

        #region Queries
        private readonly string acc_select_all = @"SELECT *, ISNULL(acc_holder_address_door + ', ', '') + ISNULL(acc_holder_address_street + ', ', '') + ISNULL(acc_holder_address_city + ', ', '') + ISNULL(acc_holder_address_post_code, '') AS acc_holder_address FROM [Accounts]";
        private readonly string acc_select_by_id = @"SELECT * FROM [Accounts] WHERE acc_id = {0}";
        private readonly string acc_select_by_holder_id = @"SELECT * FROM [Accounts] WHERE acc_holder_id = '{0}'";
        private readonly string acc_select_by_holder_name = @"SELECT * FROM [Accounts] WHERE acc_holder_name = '{0}'";
        private readonly string acc_select_by_account_type = @"SELECT * FROM [Accounts] WHERE acc_account_type = '{0}' ORDER BY acc_id";
        private readonly string acc_select_by_holder_id_and_type = @"SELECT * FROM [Accounts] WHERE acc_holder_id = '{0}' AND acc_account_type = '{1}'";
        private readonly string acc_select_by_status = @"SELECT * FROM [Accounts] WHERE acc_is_closed = '{0}' ORDER BY acc_id";
        #endregion

        public async Task<List<AccountSelect>> SelectAll()
        {
            var query = acc_select_all;
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<AccountSelect>)await sqlCon.QueryAsync<AccountSelect>(query);
                return result;
            }
        }

        public async Task<AccountSelect> SelectById(int id)
        {
            var query = string.Format(acc_select_by_id, id);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = await sqlCon.QueryFirstOrDefaultAsync<AccountSelect>(query);
                return result;
            }
        }

        public async Task<List<AccountSelect>> SelectByType(string type)
        {
            var query = string.Format(acc_select_by_account_type, type);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<AccountSelect>)await sqlCon.QueryAsync<AccountSelect>(query);
                return result;
            }
        }

        public async Task<List<AccountSelect>> SelectByHolderIdAndType(string holderId, string accountType) 
        {
            var query = string.Format(acc_select_by_holder_id_and_type, holderId, accountType);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<AccountSelect>)await sqlCon.QueryAsync<AccountSelect>(query);
                return result;
            }
        }

        public async Task<List<AccountSelect>> SelectByStatus(bool status)
        {
            var query = string.Format(acc_select_by_status, status);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<AccountSelect>)await sqlCon.QueryAsync<AccountSelect>(query);
                return result;
            }
        }

        public async Task<RequestResponse> Insert(AccountInsert model)
        {
            var reqResponse = new RequestResponse();
            var exists = await SelectByHolderIdAndType(model.acc_holder_id, model.acc_account_type);
            if (exists.Count > 0)
            {
                return new RequestResponse() { success = false, statusCode = HttpStatusCode.BadRequest, message = StatusMessage.DuplicateRow };
            }

            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    await sqlCon.InsertAsync<AccountInsert>(model);
                    return new RequestResponse() { success = true, statusCode = HttpStatusCode.OK, message = StatusMessage.Success };
                }
                catch (Exception ex)
                {
                    reqResponse.statusCode = HttpStatusCode.BadRequest;
                    reqResponse.message = ex.Message;
                }
                return reqResponse;
            }
        }

        public async Task<RequestResponse> Update(AccountUpdate model)
        {
            var reqResponse = new RequestResponse();
            var existing = await SelectByHolderIdAndType(model.acc_holder_id, model.acc_account_type);
            if (existing.Count > 1)
            {
                return new RequestResponse() { success = false, statusCode = HttpStatusCode.BadRequest, message = StatusMessage.DuplicateRow };
            }

            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    await sqlCon.UpdateAsync<AccountUpdate>(model);
                    return new RequestResponse() { success = true, statusCode = HttpStatusCode.OK, message = StatusMessage.Success };
                }
                catch (Exception ex)
                {
                    reqResponse.statusCode = HttpStatusCode.BadRequest;
                    reqResponse.message = ex.Message;
                }
                return reqResponse;
            }
        }

        public async Task<RequestResponse> AccountCheckbookAndCardUpdate(AccountCheckbookAndCardUpdate model)
        {
            var reqResponse = new RequestResponse();
            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    await sqlCon.UpdateAsync<AccountCheckbookAndCardUpdate>(model);
                    return new RequestResponse() { success = true, statusCode = HttpStatusCode.OK, message = StatusMessage.Success };
                }
                catch (Exception ex)
                {
                    reqResponse.statusCode = HttpStatusCode.BadRequest;
                    reqResponse.message = ex.Message;
                }
                return reqResponse;
            }
        }

        public Task<RequestResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
