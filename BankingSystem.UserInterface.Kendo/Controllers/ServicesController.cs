using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using BankingSystem.UserInterface.Kendo.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankingSystem.UserInterface.Kendo.Controllers
{
    public class ServicesController : Controller
    {
        private IRepoAccounts _repoAccounts;
        private IRepoRecurrings _repoRecurrings;
        private SelectHelper _selectHelper;

        public ServicesController(IRepoAccounts repoAccounts, IRepoRecurrings repoRecurrings, SelectHelper selectHelper)
        {
            _repoAccounts = repoAccounts;
            _repoRecurrings = repoRecurrings;
            _selectHelper = selectHelper;
        }

        public async Task<IActionResult> AccountInformation()
        {
            var transaction = new TransactionHistory();
            ViewBag.Accounts = await _selectHelper.AccountsList();
            return View("~/Views/Services/AccountInformation.cshtml", transaction);
        }

        public async Task<IActionResult> CheckBookAndCards()
        {
            var account = new AccountSelect();
            ViewBag.AccountType = await _selectHelper.AccountTypesList();
            return View("~/Views/Services/CheckBookAndCards.cshtml", account);
        }

        public async Task<IActionResult> RecurringPayments()
        {
            var recurrings = new RecurringSelect();
            ViewBag.Accounts = await _selectHelper.AccountsList();
            ViewBag.DayOfMonth = await _selectHelper.DayOfMonth();
            return View("~/Views/Services/RecurringPayments.cshtml", recurrings);
        }

        [HttpPost]
        public async Task<IActionResult> RecurringInsert([FromBody] RecurringInsert recurring)
        {
            var reqResponse = await _repoRecurrings.Insert(recurring);
            return Json(reqResponse);
        }

        [HttpPost]
        public async Task<IActionResult> RecurringUpdate([FromBody] RecurringUpdate recurring)
        {
            var reqResponse = await _repoRecurrings.Update(recurring);
            return Json(reqResponse);
        }

        #region AJAX Calls

        [HttpGet]
        public async Task<IActionResult> SelectRecurringBySourceAccountId(int acc_id)
        {
            var recurrings = await _repoRecurrings.SelectAllForSourceAccountId(acc_id);
            return Ok(new { data = recurrings });
        }

        #endregion
    }
}
