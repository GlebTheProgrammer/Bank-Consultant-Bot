using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace ChatApplication.BotDomain;

public class BotCommunication : IBotCommunication
{
    private const string BotFailAnswer = "Бот сейчас недоступен, попробуйте в другой раз";
    private readonly string url;


    public BotCommunication(string url )
    {
        this.url = url;
    }

    public HttpClient? HttpClient { get; set; }


    public async Task<string> AnswerBotAsync(string userMessage)
    {
        var messageModel = new BotTransferMessageModel()
        {
            Message = userMessage
        };
        var jsonData = JsonConvert.SerializeObject(messageModel);
        
        var request = new HttpRequestMessage();
        request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        request.RequestUri = new Uri(url);
        
        if (HttpClient is null)
        {
            throw new ArgumentException("HttpClient was not created.");
        }

        try
        {
            var response = await HttpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return BotFailAnswer;
            }

            var message = await response.Content.ReadAsStringAsync();

            return message;
        }
        catch (HttpRequestException e)
        {
            return BotFailAnswer;
        }
        catch (SocketException e)
        {
            return BotFailAnswer;
        }
        
    }
    
}