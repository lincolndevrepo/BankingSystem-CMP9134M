using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Models
{
    public class RequestResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
