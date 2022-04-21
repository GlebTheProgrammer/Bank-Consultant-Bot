using ChatApplication.Interfaces;
using ChatApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IChatRepository repository;
        public AuthenticationController(IChatRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            LoginUser loginUser = new LoginUser();
            return View(loginUser);
        }

        public IActionResult LoginIntoTheChat(LoginUser loginUser)
        {
            loginUser.Email = loginUser.Email.ToLower();
            var user = repository.GetUserByInputData(loginUser);
            if(user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                OnlineUser.Id = user.Id;
                OnlineUser.Nickname = user.Nickname;
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public IActionResult CreateAccount()
        {
            var user = new User();
            return View(user);
        }

        public IActionResult AddUserIntoDatabase(User user)
        {
            user.Email = user.Email.ToLower();
            repository.AddNewUser(user);
            return View("Index");
        }
    }
}
