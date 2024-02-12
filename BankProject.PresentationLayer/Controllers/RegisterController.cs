using BankProject.DtoLayer.Dtos.AppUserDtos;
using BankProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BankProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "Ankara",
                    District="asdasd",
                    ImageUrl="dasdasdas",
                    ConfirmCode= code
                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressfrom = new MailboxAddress("Bank Website Admin", "gknctn66@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressfrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayit icin gerekli dogrulama kodu: "+ code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Bank website onay kodu";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com",587,false);
                    smtpClient.Authenticate("gknctn66@gmail.com", "tlcx wrio qwzx yajf");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    return RedirectToAction("index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View();
        }
    }
}
