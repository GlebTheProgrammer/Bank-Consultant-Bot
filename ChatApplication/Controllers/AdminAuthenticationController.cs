using ChatApplication.Interfaces;
using ChatApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class AdminAuthenticationController : Controller
    {
        private readonly IChatRepository repository;
        private readonly IAdminCreatorAccessChecker accessChecker;
        public AdminAuthenticationController(IChatRepository repository, IAdminCreatorAccessChecker accessChecker)
        {
            this.repository = repository;
            this.accessChecker = accessChecker;
        }
        public IActionResult Index()
        {

            LoginAdmin loginAdmin = new LoginAdmin();
            return View(loginAdmin);
        }
        public IActionResult StartWorkingSession(LoginAdmin loginAdmin)
        {
            AuthenticationSettings.LoginAttempts++;
            AuthenticationSettings.newAccoutCreated = false;

            loginAdmin.Email = loginAdmin.Email.ToLower();
            var admin = repository.GetAdminByInputData(loginAdmin);
            if (admin == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                OnlineAdmin.Id = admin.Id;
                OnlineAdmin.Nickname = admin.Nickname;

                //Redirect for some new functional for admin
                return RedirectToAction("Index", "AdminHome", new { area = "" });
            }
        }

        public IActionResult CreateAdmin()
        {
            AuthenticationSettings.newAccoutCreated = false;
            AuthenticationSettings.LoginAttempts = 0;

            var admin = new Admin();
            return View(admin);
        }

        public IActionResult AddAdminIntoDatabase(Admin admin, string accessCode)
        {
            if (!accessChecker.checkForAccessCode(accessCode))
            {
                //return RedirectToAction("CreateAdmin");
                ModelState.AddModelError("accessCode", "Access code does not match.");
                return View("CreateAdmin");
            }
            else
            {
                if (admin.Email != null)
                {
                    admin.Email = admin.Email.ToLower();
                    repository.AddNewAdmin(admin);

                    AuthenticationSettings.newAccoutCreated = true;
                }
                return View("Index");
            }
        }
    }
}
