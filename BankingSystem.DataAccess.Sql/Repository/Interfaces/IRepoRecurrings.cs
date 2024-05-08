using BankingSystem.DataAccess.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Repository.Interfaces
{
    public interface IRepoRecurrings
    {
        public Task<List<RecurringSelect>> SelectAll();
        public Task<List<RecurringSelect>> SelectAllForSourceAccountId(int id);
        public Task<RequestResponse> Insert(RecurringInsert model);
        public Task<RequestResponse> Update(RecurringUpdate model);
        public Task<RequestResponse> Delete(int id);
    }
}
