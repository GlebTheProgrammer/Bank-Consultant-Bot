using ChatApplication.Interfaces;
using ChatApplication.Mapper;
using ChatApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{

    public class AdminHomeController : Controller
    {
        private readonly IChatRepository repository;
        private readonly IChatMapper chatMapper;
        public AdminHomeController(IChatRepository repository, IChatMapper chatMapper)
        {
            this.repository = repository;
            this.chatMapper = chatMapper;
        }

        public IActionResult Index()
        {
            var model = SystemOutput.systemMessages;
            return View(model);
        }

        public IActionResult ShowInputFields(int action)
        {
            switch (action)
            {
                case 1:
                    AdminAction.action = ToDoAction.DeleteUser;
                    break;
                case 2:
                    AdminAction.action = ToDoAction.ShowDialog;
                    break;
                case 3:
                    AdminAction.action = ToDoAction.DeleteDialog;
                    break;
                case 4:
                    AdminAction.action = ToDoAction.FindMessageByInput;
                    break;
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(string fullName, string email)
        {
            SystemOutput.systemMessages = new List<ChatMessage>();
            var user = repository.GetUserByFullNameAndEmail(fullName, email);
            var adminMessage = new ChatMessage
            {
                SenderName = OnlineAdmin.Nickname,
                MessageTime = DateTime.Now,
                Message = $"ФИО: {fullName}; Адрес Электронной Почты: {email}"
            };

            SystemOutput.systemMessages.Add(adminMessage);

            if (user != null && repository.DeleteUser(user))
            {
                repository.AddAdminMessage(new AdminMessage
                {
                    AdminId = OnlineAdmin.Id,
                    DatePublished = DateTime.Now,
                    UserId = user.Id,
                    Text = "Удалить Пользователя"

                });

                SystemOutput.systemMessages.Add(new ChatMessage
                {
                    SenderName = "System",
                    MessageTime = DateTime.Now,
                    Message = "Пользователь удалён успешно"
                });
            }
            else
            {
                SystemOutput.systemMessages.Add(new ChatMessage
                {
                    SenderName = "System",
                    MessageTime = DateTime.Now,
                    Message = "Ошибка: Пользователь не был найден"
                });
            }
            return RedirectToAction("Index");
        }

        public IActionResult ShowDialog(string fullName, string email)
{
            var user = repository.GetUserByFullNameAndEmail(fullName, email);
            SystemOutput.systemMessages = new List<ChatMessage>();

            var adminMessage = new ChatMessage
            {
                SenderName = OnlineAdmin.Nickname,
                MessageTime = DateTime.Now,
                Message = $"ФИО: {fullName}; Адрес Электронной Почты: {email}"
            };
            SystemOutput.systemMessages.Add(adminMessage);

            if (user != null)
            {
                repository.AddAdminMessage(new AdminMessage
                {
                    AdminId = OnlineAdmin.Id,
                    DatePublished = DateTime.Now,
                    UserId = user.Id,
                    Text = "Просмотерть Чат Пользователя"
                });

                OnlineUser.Id = user.Id;
                OnlineUser.Nickname = user.Nickname;

                var chat = chatMapper.MapIntoChat();

                OnlineUser.Id = 0;
                OnlineUser.Nickname = null;


                SystemOutput.systemMessages.Add(new ChatMessage
                {
                    SenderName = "System",
                    MessageTime = DateTime.Now,
                    Message = "Переписка пользователя отображена ниже:"
                });

                foreach (var chatMessage in chat)
                {
                    SystemOutput.systemMessages.Add(chatMessage);
                }
            }
            else
            {
                SystemOutput.systemMessages.Add(new ChatMessage
                {
                    SenderName = "System",
                    MessageTime = DateTime.Now,
                    Message = "Ошибка: Пользователь не был найден"
                });
            }
            return RedirectToAction("Index");
        }
    }
}
