using Microsoft.AspNetCore.Mvc;

namespace BankProject.PresentationLayer.Areas.CustomerPanel.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
