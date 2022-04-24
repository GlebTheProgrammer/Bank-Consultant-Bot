using IdentityModel.Client;

namespace ChatApplication.ApiAuthenticationDomain;

public interface IAuthenticateApi
{
    public Task<TokenResponse?> GetAuthToken();

    public HttpClient? HttpClient { get; set; }
}