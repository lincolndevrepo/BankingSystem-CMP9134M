using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;

namespace BankingSystem.UserInterface.Kendo.Controllers
{
    public class HomeController : Controller
    {
        private IRepoAppSettings _repoAppSettings;
        public HomeController(IRepoAppSettings repoAppSettings)
        {
            _repoAppSettings = repoAppSettings;
        }

        public async Task<IActionResult> SqlCheck()
        {
            var sqlStatus = await _repoAppSettings.SqlCheck();
            ViewBag.SqlStatus = "SUCCESS: " + sqlStatus.message;
            return View("~/Views/Home/SqlCheck.cshtml");
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
