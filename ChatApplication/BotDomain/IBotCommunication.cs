namespace ChatApplication.BotDomain;

public interface IBotCommunication
{
    public Task<string> AnswerBotAsync(string userMessage);

    public HttpClient? HttpClient { get; set; }
}