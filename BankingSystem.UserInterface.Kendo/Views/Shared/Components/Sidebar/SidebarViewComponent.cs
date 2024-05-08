using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.UserInterface.Kendo.Views.Shared.Components.Sidebar
{
    public class SidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View());
        }
    }
}
