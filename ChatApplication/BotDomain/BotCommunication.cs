namespace ChatApplication.BotDomain;

public class BotCommunication : IBotCommunication
{
    private readonly string url; 
    
    
    public BotCommunication(string url )
    {
        this.url = url;
    }

    public HttpClient? HttpClient { get; set; }


    public async Task<string> AnswerBotAsync(string userMessage)
    {
        var request = new HttpRequestMessage();
        request.Content = new StringContent(userMessage);
        request.RequestUri = new Uri(url);
        if (HttpClient is null)
        {
            throw new ArgumentException("HttpClient was not created.");
        }
        var responseMessage = await HttpClient.SendAsync(request);

        var message = await responseMessage.Content.ReadAsStringAsync();

        return message;
    }
    
}