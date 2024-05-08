using BankingSystem.Common.Utilities;
using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Repository.Services
{
    public class RepoRecurrings : IRepoRecurrings
    {
        #region Declarations
        private readonly DapperContext Context;
        private SessionUserInfo sessionUserInfo = new SessionUserInfo();
        private AppSettingsSelect appSettings = new AppSettingsSelect();
        #endregion

        public RepoRecurrings(DapperContext context)
        {
            Context = context;
        }

        #region Queries
        private readonly string rdd_select_all = @"SELECT * FROM [Recurrings] ORDER BY rdd_id";
        private readonly string rdd_select_by_source_account_id = @"SELECT Recurrings.*, accDebit.acc_account_number AS acc_number_debit, accDebit.acc_holder_name AS acc_holder_name_debit, accDebit.acc_account_type AS acc_account_type_debit, accCredit.acc_account_number AS acc_number_credit, accCredit.acc_holder_name AS acc_holder_name_credit, accCredit.acc_account_type AS acc_account_type_credit FROM Accounts AS accDebit INNER JOIN Recurrings ON accDebit.acc_id = Recurrings.rdd_debit_acc_id_fk INNER JOIN Accounts AS accCredit ON Recurrings.rdd_credit_acc_id_fk = accCredit.acc_id WHERE (Recurrings.rdd_debit_acc_id_fk = '{0}') ORDER BY Recurrings.rdd_id";
        #endregion

        public async Task<List<RecurringSelect>> SelectAll()
        {
            var query = rdd_select_all;
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<RecurringSelect>)await sqlCon.QueryAsync<RecurringSelect>(query);
                return result;
            }
        }

        public async Task<List<RecurringSelect>> SelectAllForSourceAccountId(int id)
        {
            var query = string.Format(rdd_select_by_source_account_id, id);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<RecurringSelect>)await sqlCon.QueryAsync<RecurringSelect>(query);
                return result;
            }
        }

        public async Task<RequestResponse> Insert(RecurringInsert model)
        {
            var reqResponse = new RequestResponse();
            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    await sqlCon.InsertAsync<RecurringInsert>(model);
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

        public async Task<RequestResponse> Update(RecurringUpdate model)
        {
            var reqResponse = new RequestResponse();
            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    await sqlCon.UpdateAsync<RecurringUpdate>(model);
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
