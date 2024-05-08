using BankingSystem.DataAccess.Sql.Models;

namespace BankingSystem.DataAccess.Sql.Repository.Interfaces
{
    public interface IRepoTransactions
    {
        public Task<List<TransactionSelect>> SelectAll();
        public Task<List<TransactionSelect>> SelectAllByDateAndType(DateTime vDate, string vType);
        public Task<List<TransactionSelect>> SelectAllByAccountId(int accountId);
        public Task<decimal> SelectOpeningBalanceById(string accountId, string fromDate);
        public Task<List<TransactionSelect>> SelectAllByAccountIdAndDateRange(string accountId, string fromDate, string toDate);
        public Task<List<TransactionSelect>> SelectForEdit(DateTime vDate, string vType, int vNo, int otherAccountId);
        public Task<RequestResponse> Insert(TransactionInsert model);
        public Task<RequestResponse> Update(TransactionUpdate model);
        public Task<RequestResponse> Delete(int id);
        public Task<TransactionSelect> NewTransaction(DateTime date, string vType);
    }
}
