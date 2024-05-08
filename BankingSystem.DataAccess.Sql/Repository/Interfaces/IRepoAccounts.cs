using BankingSystem.DataAccess.Sql.Models;

namespace BankingSystem.DataAccess.Sql.Repository.Interfaces
{
    public interface IRepoAccounts
    {
        public Task<List<AccountSelect>> SelectAll();
        public Task<AccountSelect> SelectById(int id);
        public Task<List<AccountSelect>> SelectByType(string type);
        public Task<List<AccountSelect>> SelectByHolderIdAndType(string holderId, string accountType);
        public Task<List<AccountSelect>> SelectByStatus(bool status);
        public Task<RequestResponse> Insert(AccountInsert model);
        public Task<RequestResponse> Update(AccountUpdate model);
        public Task<RequestResponse> AccountCheckbookAndCardUpdate(AccountCheckbookAndCardUpdate model);
        public Task<RequestResponse> Delete(int id);
    }
}
