using ChatApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<ChatMessage>();
            return View(model);
        }
    }
}
