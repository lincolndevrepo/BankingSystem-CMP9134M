using BankingSystem.Common.Utilities;
using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Repository.Services
{
    public class RepoAppSettings : IRepoAppSettings
    {
        #region Declarations
        private readonly DapperContext Context;
        private SessionUserInfo sessionUserInfo = new SessionUserInfo();
        private AppSettingsSelect appSettings = new AppSettingsSelect();
        #endregion

        public RepoAppSettings(DapperContext context)
        {
            Context = context;
        }

        public async Task<RequestResponse> SqlCheck()
        {
            var reqResponse = new RequestResponse();
            var conString = string.Empty;
            using (var sqlCon = Context.CreateConnection())
            {
                try
                {
                    conString = sqlCon.ConnectionString;
                    sqlCon.Open();
                    return new RequestResponse() { success = true, statusCode = HttpStatusCode.OK, message = StatusMessage.SuccessSqlConnection };
                }
                catch (SqlException ex)
                {
                    reqResponse.statusCode = HttpStatusCode.BadRequest;
                    reqResponse.message = "ERROR:" + Environment.NewLine + "Connection String" + conString + Environment.NewLine + ex.Message;
                }
                return reqResponse;
            }
        }
    }
}
