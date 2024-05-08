using BankingSystem.DataAccess.Sql.Models;

namespace BankingSystem.DataAccess.Sql.Repository.Interfaces
{
    public interface IRepoUsers
    {
        public Task<List<UserSelect>> SelectAll();
        public Task<UserSelect> SelectById(int id);
        public Task<List<UserSelect>> SelectByEmail(string email);
        public Task<List<UserSelect>> SelectByStatus(bool status);
        public Task<UserSelect> SelectByEmailAndPassword(string email, string password);
        public Task<RequestResponse> Insert(UserInsert model);
        public Task<RequestResponse> Update(UserUpdate model);
        public Task<RequestResponse> Delete(int id);
    }
}
