using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.DataAccess.Sql.Models;


namespace BankingSystem.DataAccess.Sql.Repository.Interfaces
{
    public interface IRepoAppSettings
    {
        public Task<RequestResponse> SqlCheck();
    }
}
