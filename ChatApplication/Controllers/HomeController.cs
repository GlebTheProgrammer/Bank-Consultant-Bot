using ChatApplication.Interfaces;
using ChatApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChatRepository repository;
        private readonly IChatMapper chatMapper;
        public HomeController(IChatRepository repository, IChatMapper chatMapper)
        {
            this.repository = repository;
            this.chatMapper = chatMapper;
        }

        public IActionResult Index()
        {
            var chat = chatMapper.MapIntoChat();

            var model = new List<ChatMessage>();

            foreach (var chatMessage in chat)
            {
                model.Add(chatMessage);
            }

            return View(model);
        }

        public IActionResult CreateMessage(string message)
        {
            if(string.IsNullOrEmpty(message))
                return RedirectToAction("Index");

            if(OnlineUser.Id==0)
                return RedirectToAction("Index");

            repository.AddUserMesage(new UserMessage
            {
                Text = message,
                DatePublished = DateTime.Now,
                UserId = OnlineUser.Id
            });

            return RedirectToAction("Index");
        }
    }
}
