using ChatApplication.ApiAuthenticationDomain;
using ChatApplication.BotDomain;
using ChatApplication.Interfaces;
using ChatApplication.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChatRepository repository;
        private readonly IChatMapper chatMapper;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IBotCommunication botCommunication;
        private readonly IAuthenticateApi authenticateApi;
        
        public HomeController(IChatRepository repository, IChatMapper chatMapper, IHttpClientFactory httpClientFactory, IBotCommunication botCommunication, IAuthenticateApi authenticateApi)
        {
            this.repository = repository;
            this.chatMapper = chatMapper;
            this.httpClientFactory = httpClientFactory;
            this.botCommunication = botCommunication;
            this.authenticateApi = authenticateApi;
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

        public async Task<IActionResult> CreateMessage(string message)
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
            
            var authClient = httpClientFactory.CreateClient();
            authenticateApi.HttpClient = authClient;
            var token = await authenticateApi.GetAuthToken();
            if (token is null)
            {
                throw new ArgumentException("Auth token is empty.");
            }
            
            var botClient = httpClientFactory.CreateClient();
            botClient.SetBearerToken(token.AccessToken);
            botCommunication.HttpClient = botClient;
            var botMessage = await botCommunication.AnswerBotAsync(message);

            repository.AddBotMessage(new BotMessage
            {
                UserId = OnlineUser.Id,
                DatePublished= DateTime.Now,
                Text = botMessage,
            });    

            return RedirectToAction("Index");
        }
    }
}
