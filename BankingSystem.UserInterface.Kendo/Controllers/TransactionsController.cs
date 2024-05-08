using BankingSystem.DataAccess.Sql.Models;
using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using BankingSystem.UserInterface.Kendo.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BankingSystem.UserInterface.Kendo.Controllers
{
    public class TransactionsController : Controller
    {
        private IRepoAccounts _repoAccounts;
        private IRepoTransactions _repoTransactions;
        private SelectHelper _selectHelper;

        public TransactionsController(IRepoAccounts repoAccounts, IRepoTransactions repoTransactions, SelectHelper selectHelper)
        {
            _repoAccounts = repoAccounts;
            _repoTransactions = repoTransactions;
            _selectHelper = selectHelper;
        }

        public async Task<IActionResult> Deposit()
        {
            var transaction = new TransactionSelect();
            ViewBag.Accounts = await _selectHelper.AccountsList();
            return View("~/Views/Transactions/Deposit.cshtml", transaction);
        }

        public async Task<IActionResult> Withdraw()
        {
            var transaction = new TransactionSelect();
            ViewBag.Accounts = await _selectHelper.AccountsList();
            return View("~/Views/Transactions/Withdraw.cshtml", transaction);
        }

        public async Task<IActionResult> Transfer()
        {
            var transaction = new TransactionSelect();
            ViewBag.Accounts = await _selectHelper.AccountsList();
            return View("~/Views/Transactions/Transfer.cshtml", transaction);
        }

        public async Task<IActionResult> History()
        {
            var transaction = new TransactionHistory();
            ViewBag.Accounts = await _selectHelper.AccountsList();
            return View("~/Views/Transactions/History.cshtml", transaction);
        }

        [HttpPost]
        public async Task<IActionResult> ShowStatementPartial([FromBody] TransactionHistory history)
        {
            return PartialView("~/Views/Transactions/_AccountStatementPartial.cshtml", history);
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllByAccountIdAndDateRange(string acc_id, string date_from, string date_to)
        {
            var date_from_US = DateTime.ParseExact(date_from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var date_to_US = DateTime.ParseExact(date_to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var openingBal = await _repoTransactions.SelectOpeningBalanceById(acc_id, date_from_US.ToString("yyyy-MM-dd"));
            var transactions = await _repoTransactions.SelectAllByAccountIdAndDateRange(acc_id, date_from_US.ToString("yyyy-MM-dd"), date_to_US.ToString("yyyy-MM-dd"));
            var firstTransaction = transactions.FirstOrDefault();
            transactions[0].trn_opn_balance = openingBal;
            decimal previousClsBalance = firstTransaction.trn_opn_balance + firstTransaction.trn_cramount - firstTransaction.trn_dramount;
            transactions[0].trn_cls_balance = previousClsBalance;
            for (int i = 1; i < transactions.Count; i++)
            {
                var transaction = transactions[i];
                transactions[i].trn_opn_balance = previousClsBalance;
                transactions[i].trn_cls_balance = transaction.trn_opn_balance + transaction.trn_cramount - transaction.trn_dramount;
                previousClsBalance = transaction.trn_cls_balance;
            }

            return Ok(new { data = transactions }); 
        }

        [HttpPost]
        public async Task<IActionResult> SelectStatementByAccountId(int acc_id)
        {
            var transactions = await _repoTransactions.SelectAllByAccountId(acc_id);
            var firstTransaction = transactions.FirstOrDefault();
            decimal previousClsBalance = firstTransaction.trn_opn_balance + firstTransaction.trn_cramount - firstTransaction.trn_dramount;
            transactions[0].trn_cls_balance = previousClsBalance;
            for (int i = 1; i < transactions.Count; i++)
            {
                var transaction = transactions[i];
                transactions[i].trn_opn_balance = previousClsBalance;
                transactions[i].trn_cls_balance = transaction.trn_opn_balance + transaction.trn_cramount - transaction.trn_dramount;
                previousClsBalance = transaction.trn_cls_balance;
            }
            return PartialView("/Views/Transactions/_AccountStatementPartial.cshtml", transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TransactionInsert transaction)
        {
            var reqResponse = await _repoTransactions.Insert(transaction);
            return Json(reqResponse);
        }

        #region AJAX Calls

        [HttpPost]
        public async Task<IActionResult> SelectAllByAccountId(int acc_id)
        {
            var transactions = await _repoTransactions.SelectAllByAccountId(acc_id);
            var firstTransaction = transactions.FirstOrDefault();
            decimal previousClsBalance = firstTransaction.trn_opn_balance + firstTransaction.trn_cramount - firstTransaction.trn_dramount;
            transactions[0].trn_cls_balance = previousClsBalance;
            for (int i = 1; i < transactions.Count; i++)
            {
                var transaction = transactions[i];
                transactions[i].trn_opn_balance = previousClsBalance;
                transactions[i].trn_cls_balance = transaction.trn_opn_balance + transaction.trn_cramount - transaction.trn_dramount;
                previousClsBalance = transaction.trn_cls_balance;
            }
            return Ok(new { data = transactions });
        }

        [HttpPost]
        public async Task<IActionResult> SelectBalanceByAccountId(int acc_id)
        {
            var transactions = await _repoTransactions.SelectAllByAccountId(acc_id);
            var sumDeposits = transactions.Sum(x => x.trn_cramount);
            var sumWithdraw = transactions.Sum(x => x.trn_dramount);
            var clsBalance = sumDeposits - sumWithdraw;
            var transaction = new TransactionSelect() { trn_cls_balance = clsBalance };
            return Json(transaction);
        }

        #endregion
    }
}
