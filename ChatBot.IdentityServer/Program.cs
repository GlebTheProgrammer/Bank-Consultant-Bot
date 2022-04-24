using ChatBot.IdentityServer.ConfigurationModels;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddIdentityServer()
    .AddInMemoryClients(Configuration.GetClients())
    .AddInMemoryApiResources(Configuration.GetApiResources())
    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
    .AddInMemoryApiScopes(Configuration.Scopes)
    .AddDeveloperSigningCredential();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseIdentityServer();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();