using BankingSystem.Common.Utilities;
using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Repository.Services
{
    public class RepoTransactions : IRepoTransactions
    {
        #region Declarations
        private readonly DapperContext Context;
        private SessionUserInfo sessionUserInfo = new SessionUserInfo();
        private AppSettingsSelect appSettings = new AppSettingsSelect();
        #endregion

        public RepoTransactions(DapperContext context)
        {
            Context = context;
        }

        #region Queries
        private readonly string trn_select_all = @"SELECT * FROM [Transactions] ORDER BY trn_id";
        private readonly string trn_select_by_id = @"SELECT * FROM [Transactions] WHERE trn_acc = '{0}'";
        private readonly string trn_select_by_account_id = @"SELECT * FROM [Transactions] WHERE trn_acc_id_fk = '{0}' ORDER BY trn_id";
        private readonly string trn_select_opening_by_account_id_and_from_date = @"SELECT SUM(trn_cramount)-SUM(trn_dramount) AS trn_opn_balance FROM [Transactions] WHERE trn_acc_id_fk = '{0}' AND FORMAT(trn_date, 'yyyy-MM-dd') < '{1}'";
        private readonly string trn_select_by_account_id_and_date_range = @"SELECT * FROM [Transactions] WHERE trn_acc_id_fk = '{0}' AND FORMAT(trn_date, 'yyyy-MM-dd') >= '{1}' AND FORMAT(trn_date, 'yyyy-MM-dd') <= '{2}'";
        #endregion

        public async Task<List<TransactionSelect>> SelectAll()
        {
            var query = trn_select_all;
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<TransactionSelect>)await sqlCon.QueryAsync<TransactionSelect>(query);
                return result;
            }
        }

        public Task<List<TransactionSelect>> SelectAllByDateAndType(DateTime vDate, string vType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransactionSelect>> SelectAllByAccountId(int accountId)
        {
            var query = string.Format(trn_select_by_account_id, accountId);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<TransactionSelect>)await sqlCon.QueryAsync<TransactionSelect>(query);
                return result;
            }
        }

        public async Task<decimal> SelectOpeningBalanceById(string accountId, string fromDate)
        {
            var query = string.Format(trn_select_opening_by_account_id_and_from_date, accountId, fromDate);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (decimal)await sqlCon.ExecuteScalarAsync<decimal>(query);
                return result;
            }
        }

        public async Task<List<TransactionSelect>> SelectAllByAccountIdAndDateRange(string accountId, string fromDate, string toDate)
        {
            var query = string.Format(trn_select_by_account_id_and_date_range, accountId, fromDate, toDate);
            using (var sqlCon = Context.CreateConnection())
            {
                var result = (List<TransactionSelect>)await sqlCon.QueryAsync<TransactionSelect>(query);
                return result;
            }
        }

        public Task<List<TransactionSelect>> SelectForEdit(DateTime vDate, string vType, int vNo, int otherAccountId)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResponse> Insert(TransactionInsert model)
        {
            var reqResponse = new RequestResponse();
            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    await sqlCon.InsertAsync<TransactionInsert>(model);
                    if (model.trn_type == "T")
                    {
                        var beneficiary = new TransactionInsert()
                        {
                            trn_date = model.trn_date,
                            trn_type = model.trn_type,
                            trn_receipt_no = model.trn_receipt_no,
                            trn_acc_id_fk = model.trn_acc_id_fk_to,
                            trn_description = model.trn_description,
                            trn_cramount = model.trn_dramount
                        };
                        await sqlCon.InsertAsync<TransactionInsert>(beneficiary);
                    }
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

        public Task<RequestResponse> Update(TransactionUpdate model)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionSelect> NewTransaction(DateTime date, string vType)
        {
            throw new NotImplementedException();
        }
    }
}
