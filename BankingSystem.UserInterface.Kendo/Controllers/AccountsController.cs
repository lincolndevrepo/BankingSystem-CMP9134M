using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using BankingSystem.UserInterface.Kendo.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.UserInterface.Kendo.Controllers
{
    public class AccountsController : Controller
    {
        private IRepoAccounts _repoAccounts;
        private SelectHelper _selectHelper;

        public AccountsController(IRepoAccounts repoAccounts, SelectHelper selectHelper)
        {
            _repoAccounts = repoAccounts;
            _selectHelper = selectHelper;
        }

        public async Task<IActionResult> Index()
        {
            var account = new AccountSelect();
            ViewBag.AccountType = await _selectHelper.AccountTypesList();
            return View("~/Views/Accounts/Index.cshtml", account);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] AccountInsert account)
        {
            var reqResponse = await _repoAccounts.Insert(account);
            return Json(reqResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] AccountUpdate account)
        {
            var reqResponse = await _repoAccounts.Update(account);
            return Json(reqResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AccountCheckbookAndCardUpdate([FromBody] AccountCheckbookAndCardUpdate account)
        {
            var reqResponse = await _repoAccounts.AccountCheckbookAndCardUpdate(account);
            return Json(reqResponse);
        }

        #region AJAX Calls

        [HttpGet]
        public async Task<IActionResult> SelectAllAccounts()
        {
            var accounts = await _repoAccounts.SelectAll();
            return Ok(new { data = accounts });
        }

        [HttpPost]
        public async Task<IActionResult> SelectAccountById(int acc_id)
        {
            var account_info = await _repoAccounts.SelectById(acc_id);
            return Json(account_info);
        }

        #endregion
    }
}
