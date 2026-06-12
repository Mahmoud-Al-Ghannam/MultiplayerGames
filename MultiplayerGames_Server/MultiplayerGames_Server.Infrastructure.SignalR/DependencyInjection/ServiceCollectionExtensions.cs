using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerGames_Server.Application.Broadcasters.XOGame;
using MultiplayerGames_Server.Infrastructure.SignalR.Persistence.Data;
using MultiplayerGames_Server.Infrastructure.SignalR.Services;
using MultiplayerGames_Server.Infrastructure.SignalR.Services.Broadcasters;
using SignalRHubDocs;

namespace MultiplayerGames_Server.Infrastructure.SignalR.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureSignalR(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Configure SQLite file‑based database
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=multiplayer-games.db"; // fallback

        services.AddDbContext<SignalRDbContext>(options =>
            options.UseSqlite(connectionString).EnableDetailedErrors(true)
        );

        services.AddSignalRDocumentation(options =>
        {
            options.Title = "XO Game SignalR API";
            options.Description = "Interactive documentation for real-time game hubs";
            options.Version = "1.0.0";
            options.RoutePrefix = "/signalr-docs"; // The URL path for the UI

            // 👇 Add Bearer token authentication
            options.SupportedAuthSchemes.Add(
                new AuthScheme
                {
                    Name = "Bearer",
                    Type = AuthType.QueryParam,
                    QueryParamName = "access_token",
                    Description = "JWT Bearer token authentication",
                    IsDefault = true,
                }
            );
        });

        services.AddSignalR(options => // Ensure your SignalR service is added
        {
            options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
            options.KeepAliveInterval = TimeSpan.FromSeconds(15);
            options.EnableDetailedErrors = true;
        });

        services.AddScoped<IXOGameBroadcaster, XOGameBroadcaster>();
        services.AddScoped<HubGroupManager>();

        return services;
    }
}
