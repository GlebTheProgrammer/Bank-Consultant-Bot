using System.Security;
using Google.Cloud.Dialogflow.V2;
using Environment = System.Environment;

namespace OtoBot;

public class DialogflowManager
{
    private const string DefaultProjectId = "test-cuhj";
    private const string DefaultUserId = "123";
    
    private string _userID;
    private string _projectId;
    private SessionsClient _sessionsClient;
    private SessionName _sessionName;

    public DialogflowManager() {

        _userID = DefaultUserId;
        _projectId = DefaultProjectId;
        SetEnvironmentVariable();

    }

    private void SetEnvironmentVariable() {
        try {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\Lenovo\Downloads\test-cuhj-22e8957b999b.json");
        } catch (ArgumentNullException) {
            throw;
        } catch (ArgumentException) {
            throw;
        } catch (SecurityException) {
            throw;
        }
    }

    private async Task CreateSession() {
        // Create client
        _sessionsClient = await SessionsClient.CreateAsync();
        // Initialize request argument(s)
        _sessionName = new SessionName(_projectId, _userID);

    }

    public async Task < QueryResult > CheckIntent(string userInput, string LanguageCode = "ru") {
        await CreateSession();
        QueryInput queryInput = new QueryInput();
        var queryText = new TextInput();
        queryText.Text = userInput;
        queryText.LanguageCode = LanguageCode;
        queryInput.Text = queryText;

        // Make the request
        DetectIntentResponse response = await _sessionsClient.DetectIntentAsync(_sessionName, queryInput);
        return response.QueryResult;
    }
}