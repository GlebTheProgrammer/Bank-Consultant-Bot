namespace OtoBot;

public static class Message
{
    public static async Task<string> GetBotAnswer(string userMessage)
    {
        
        var dialogflow = new DialogflowManager();

        var dialogflowQueryResult = await dialogflow.CheckIntent(userMessage);

        return dialogflowQueryResult.FulfillmentText;
    }
}