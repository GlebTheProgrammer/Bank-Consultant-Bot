using ChatApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class AdminAuthenticationController : Controller
    {
        private readonly IChatRepository repository;
        public AdminAuthenticationController(IChatRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
