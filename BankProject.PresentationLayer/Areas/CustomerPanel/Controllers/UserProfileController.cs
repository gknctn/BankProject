
using BankProject.BusinessLayer.Concrete;
using BankProject.DataAccessLayer.Concrete;
using BankProject.DtoLayer.Dtos.AppUserDtos;
using BankProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankProject.PresentationLayer.Areas.CostumerPanel.Controllers
{
    [Area("CustomerPanel")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProfileDetail()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> ProfileEdit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ProfileEdit(AppUser customer)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = customer.Name;
            user.Surname = customer.Surname;
            user.UserName = customer.UserName;
            user.Email = customer.Email;
            user.PhoneNumber = customer.PhoneNumber;
            user.District = customer.District;
            user.City = customer.City;
            user.ImageUrl = customer.ImageUrl;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("ProfileDetail");
        }

        [HttpGet]
        public IActionResult ProfilePasswordChange()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProfilePasswordChange(ChangePassworDto changePassworDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (changePassworDto.NewPassword == changePassworDto.NewPasswordConfirm)
            {
                await _userManager.ChangePasswordAsync(user, changePassworDto.CurrentPassword, changePassworDto.NewPassword);
                return RedirectToAction("ProfileDetail");
            }
            else
            {
                return RedirectToAction("ProfileEdit");
            }
        }
        [HttpGet]
        public IActionResult UserContact()
        {
            return View();
        }
        
    }
}
