using IdentityModel;
using IdentityServer4.Models;

namespace ChatBot.IdentityServer.ConfigurationModels;

public static class Configuration
{
    public static IEnumerable<Client> GetClients() => new List<Client>
    {
        new()
        {
            ClientId = "client_id",
            ClientSecrets = {new Secret("client_secret".ToSha256())},
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes =
            {
                "BotApi"
            },
            
        }
    };

    public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>
    {
        new("BotApi")
    };
    
    public static List<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),

        };
    }
    
    public static IEnumerable<ApiScope> Scopes
    {
        get
        {
            return new List<ApiScope> 
            { 
                new ApiScope("BotApi", "Friendly bot api") 
            };
        }
    }
}