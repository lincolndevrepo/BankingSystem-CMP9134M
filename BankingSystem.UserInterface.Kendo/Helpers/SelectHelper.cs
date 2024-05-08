using BankingSystem.DataAccess.Sql.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankingSystem.UserInterface.Kendo.Helpers
{
    public class SelectHelper
    {
        protected IRepoAccounts _repoAccounts;
        protected IRepoRecurrings _repoRecurrings;
        protected IRepoUsers _repoUsers;

        public List<SelectListItem> cnicList = new List<SelectListItem>();
        public List<SelectListItem> casteList = new List<SelectListItem>();
        public List<SelectListItem> relegionList = new List<SelectListItem>();
        public List<SelectListItem> plotList = new List<SelectListItem>();

        public SelectHelper(IRepoAccounts repoAccounts, IRepoRecurrings repoRecurrings, IRepoUsers repoUsers)
        {
            _repoAccounts = repoAccounts;
            _repoRecurrings = repoRecurrings;
            _repoUsers = repoUsers;
        }

        public async Task<List<SelectListItem>> AccountsList()
        {
            var accountsList = await _repoAccounts.SelectAll();
            var result = new List<SelectListItem>();
            foreach (var account in accountsList)
            {
                result.Add(new SelectListItem { Text = account.acc_account_number, Value = account.acc_id.ToString() });
            }
            return result;
        }

        public async Task<List<SelectListItem>> AccountTypesList()
        {
            var result = new List<SelectListItem>();
            result.Add(new SelectListItem { Text = "Personal", Value = "Personal" });
            result.Add(new SelectListItem { Text = "Business", Value = "Business" });
            return result;
        }

        public async Task<List<SelectListItem>> DayOfMonth()
        {
            var result = new List<SelectListItem>();
            for (int i = 1; i <= 30; i++)
            {
                result.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            return result;
        }
    }
}
