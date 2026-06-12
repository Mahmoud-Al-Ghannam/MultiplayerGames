using Microsoft.OpenApi;
using OnlineXO_Server.Application.DependencyInjection;
using OnlineXO_Server.Domain.DependencyInjection;
using OnlineXO_Server.Infrastructure.DependencyInjection;
using OnlineXO_Server.Infrastructure.SignalR.Common.Constants;
using OnlineXO_Server.Infrastructure.SignalR.DependencyInjection;
using OnlineXO_Server.Infrastructure.SignalR.Hubs.TestHub;
using OnlineXOServer.WebApi.DependencyInjection;
using OnlineXOServer.WebApi.Middlewares;
using Scalar.AspNetCore;
using SignalRHubDocs;
using XOGameHubSignalR = OnlineXO_Server.Infrastructure.SignalR.Hubs.XOGameHub.XOGameHub;

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
