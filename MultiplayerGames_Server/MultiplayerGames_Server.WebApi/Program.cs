using Microsoft.OpenApi;
using MultiplayerGames_Server.Application.DependencyInjection;
using MultiplayerGames_Server.Domain.DependencyInjection;
using MultiplayerGames_Server.Infrastructure.DependencyInjection;
using MultiplayerGames_Server.Infrastructure.SignalR.Common.Constants;
using MultiplayerGames_Server.Infrastructure.SignalR.DependencyInjection;
using MultiplayerGames_Server.Infrastructure.SignalR.Hubs.TestHub;
using MultiplayerGames_Server.WebApi.DependencyInjection;
using MultiplayerGames_Server.WebApi.Middlewares;
using Scalar.AspNetCore;
using SignalRHubDocs;
using XOGameHubSignalR = MultiplayerGames_Server.Infrastructure.SignalR.Hubs.XOGameHub.XOGameHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddWebapi(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureSignalR(builder.Configuration);
builder.Services.AddApplicationServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSignalRDocumentation();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.MapHub<TestHub>("hubs/test");
app.MapHub<XOGameHubSignalR>(HubConstants.XOGameHub.Endpoint);
app.Run();
