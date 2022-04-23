using ChatApplication.DbConfiguration;
using ChatApplication.Domain;
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

var app = builder.Build();
//app.UseMvcWithDefaultRoute();


//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default/hello",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Authentication}/{action=Index}/{id?}");

app.Run();
