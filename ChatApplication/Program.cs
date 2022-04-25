using ChatApplication.ApiAuthenticationDomain;
using ChatApplication.BotDomain;
using ChatApplication.DbConfiguration;
using ChatApplication.Interfaces;
using ChatApplication.Mapper;
using ChatApplication.Mocks;
using ChatApplication.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddDbContext<ChatDbContext>(opt => opt.UseSqlServer
    (builder.Configuration.GetConnectionString("ChatConnection")));

//Dependency Injection

//Sql Service
//builder.Services.AddScoped<IChatRepository, SqlChatRepository>();

//Mock Service
builder.Services.AddScoped<IChatRepository, MockChatRepository>();

//Additional Services
builder.Services.AddScoped<IChatMapper, ChatMapper>();
builder.Services.AddScoped<IAdminCreatorAccessChecker, AdminCreatorAccessChecker>();


//Http client
builder.Services.AddHttpClient();
var botApiUrl = builder.Configuration.GetSection("BotApiConnectionUrl").Value;
if (string.IsNullOrEmpty(botApiUrl))
{
    throw new ArgumentException("Bot api url was not found.");
}
builder.Services.AddSingleton<IBotCommunication, BotCommunication>(conf => new BotCommunication(botApiUrl));

//Auth 

builder.Services.AddHttpClient();
var authApiUrl = builder.Configuration.GetSection("AuthorityUrl").Value;
if (string.IsNullOrEmpty(authApiUrl))
{
    throw new ArgumentException("Bot api url was not found.");
}
builder.Services.AddSingleton<IAuthenticateApi, AuthenticateApi>(conf => new AuthenticateApi(authApiUrl));

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default/hello",
    pattern: "{controller=Authentication}/{action=Index}/{id?}");

app.Run();
