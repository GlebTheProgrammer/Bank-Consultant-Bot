using ChatApplication.BotDomain;
using ChatApplication.DbConfiguration;
using ChatApplication.Interfaces;
using ChatApplication.Mapper;
using ChatApplication.Mocks;
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

builder.Services.AddScoped<IChatMapper, ChatMapper>();


//Http client
builder.Services.AddHttpClient();
var botApiUrl = builder.Configuration.GetSection("BotApiConnectionUrl").Value;
if (string.IsNullOrEmpty(botApiUrl))
{
    throw new ArgumentException("Bot api url was not found.");
}
builder.Services.AddSingleton<IBotCommunication, BotCommunication>(conf => new BotCommunication("https://localhost:7266/api/WeatherForecast"));

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default/hello",
    pattern: "{controller=Authentication}/{action=Index}/{id?}");

app.Run();
