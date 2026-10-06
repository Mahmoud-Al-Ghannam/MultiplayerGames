using Hangfire;
using Hangfire.Community.Outbox.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MultiplayerGames_Server.Application.DependencyInjection;
using MultiplayerGames_Server.Domain.DependencyInjection;
using MultiplayerGames_Server.Infrastructure.DependencyInjection;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;
using MultiplayerGames_Server.Infrastructure.SignalR.Common.Constants;
using MultiplayerGames_Server.Infrastructure.SignalR.DependencyInjection;
using MultiplayerGames_Server.Infrastructure.SignalR.Hubs.TestHub;
using MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Data;
using MultiplayerGames_Server.WebApi.DependencyInjection;
using MultiplayerGames_Server.WebApi.Hangfire;
using MultiplayerGames_Server.WebApi.Middlewares;
using Scalar.AspNetCore;
using SignalRHubDocs;
using XOGameHubSignalR = MultiplayerGames_Server.Infrastructure.SignalR.Hubs.XOGameHub.XOGameHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddWebapi(builder.Configuration);
builder.Services.AddInfrastructure(builder.Environment, builder.Configuration);
builder.Services.AddInfrastructureSignalR(builder.Environment, builder.Configuration);
builder.Services.AddApplicationServices();
var app = builder.Build();

// Apply migrations (if using EF Core) – recommended before seeding
using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var signalrDbContext = scope.ServiceProvider.GetRequiredService<SignalRDbContext>();
    await appDbContext.Database.MigrateAsync();
    await signalrDbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("Multiplayers Games Server APIs")
        .WithTheme(ScalarTheme.BluePlanet)
        .WithOperationTitleSource(OperationTitleSource.Path);
});
app.UseSignalRDocumentation();

// }

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    app.MapHangfireDashboard(
        "/hangfire",
        new DashboardOptions()
        {
            Authorization = new[]
            {
                scope.ServiceProvider.GetRequiredService<MyHangfireAuthorizationFilter>(),
            },
        }
    );
}

app.UseHangfireOutbox();

app.MapHub<TestHub>("hubs/test");
app.MapHub<XOGameHubSignalR>(HubConstants.XOGameHub.Endpoint);
app.Run();
