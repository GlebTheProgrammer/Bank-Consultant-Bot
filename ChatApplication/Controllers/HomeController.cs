using ChatApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChatRepository repository;
        public HomeController(IChatRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
