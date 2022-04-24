using IdentityModel.Client;

namespace ChatApplication.ApiAuthenticationDomain;

public class AuthenticateApi : IAuthenticateApi
{
    private readonly string url;
    
    public AuthenticateApi(string url)
    {
        this.url = url;
    }

    public async Task<TokenResponse?> GetAuthToken()
    {
        if (HttpClient is null)
        {
            throw new ArgumentException("HttpClient was not created.");
        }
        var discoveryClient = await HttpClient.GetDiscoveryDocumentAsync(url);
        return await HttpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
        {
            Address = discoveryClient.TokenEndpoint,
            
            ClientId = "client_id",
            ClientSecret = "client_secret",
            Scope = "BotApi",

        });
    }

    public HttpClient? HttpClient { get; set; }
}