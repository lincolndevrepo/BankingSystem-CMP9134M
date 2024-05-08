using Dapper;
using Dapper.Contrib.Extensions;
using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BankingSystem.DataAccess.Sql.Repository.Services
{
    public class RepoUsers : IRepoUsers
    {
        #region Declarations
        private readonly DapperContext Context;
        private SessionUserInfo sessionUserInfo = new SessionUserInfo();
        #endregion

        #region Queries
        private readonly string usr_select_all = @"SELECT * FROM [Users]";
        private readonly string usr_select_all_by_email_and_password = @"SELECT * FROM [Users] WHERE usr_email = '{0}' AND usr_password = '{1}'";
        #endregion

        public RepoUsers(DapperContext context)
        {
            Context = context;
        }

        public Task<List<UserSelect>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserSelect> SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserSelect>> SelectByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserSelect>> SelectByStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSelect> SelectByEmailAndPassword(string email, string password)
        {
            var query = string.Format(usr_select_all_by_email_and_password,email, password);
            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    var result = await sqlCon.QueryFirstOrDefaultAsync<UserSelect>(query) ?? new UserSelect();
                    return result;
                }
                catch (SqlException ex)
                {
                    var error = ex.Message;
                }
                return new UserSelect();
            }
        }

        public Task<RequestResponse> Insert(UserInsert model)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> Update(UserUpdate model)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
