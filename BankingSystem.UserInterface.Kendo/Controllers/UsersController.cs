using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;

namespace BankingSystem.UserInterface.Kendo.Controllers
{
    public class UsersController : Controller
    {
        private IRepoUsers _repoUsers;
        public UsersController(IRepoUsers repoUsers)
        {
            _repoUsers = repoUsers;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserSelect credentials)
        {
            var user = await _repoUsers.SelectByEmailAndPassword(credentials.usr_email, credentials.usr_password);
            var reqResponse = new RequestResponse();
            if (user.usr_id > 0)
            {
                reqResponse.statusCode = HttpStatusCode.OK;
                reqResponse.success = true;
            }
            else
            {
                reqResponse.statusCode = HttpStatusCode.NotFound;
                reqResponse.success = false;
            }
            return Json(reqResponse);
        }
    }
}
