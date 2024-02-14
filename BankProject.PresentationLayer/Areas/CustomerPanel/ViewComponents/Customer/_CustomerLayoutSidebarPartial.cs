using BankProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankProject.PresentationLayer.Areas.CustomerPanel.ViewComponents.Customer
{
    public class _CustomerLayoutSidebarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _CustomerLayoutSidebarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}
