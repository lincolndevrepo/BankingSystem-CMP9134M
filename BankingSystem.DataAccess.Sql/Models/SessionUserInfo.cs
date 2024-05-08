using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Models
{
    public class SessionUserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string ConnString { get; set; }
    }
}
