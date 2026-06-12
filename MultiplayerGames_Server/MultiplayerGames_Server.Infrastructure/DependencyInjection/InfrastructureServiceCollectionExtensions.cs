using System;
using System.Reflection;
using Dorssel.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Data.ReadRepository;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Broadcasters.XOGame;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Infrastructure.Common.Constants;
using MultiplayerGames_Server.Infrastructure.Options;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;
using MultiplayerGames_Server.Infrastructure.Persistence.ReadRepositories;
using MultiplayerGames_Server.Infrastructure.Services;

namespace MultiplayerGames_Server.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<JwtOptions>(options =>
            configuration.GetSection("JwtOptions").Bind(options)
        );

        // Configure SQLite file‑based database
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(
                "Connection String is not found in json configuration file"
            );

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString).EnableDetailedErrors(true);
            options.UseSqliteTimestamp();
        });

        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGameReadRepository, GameReadRepository>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IGenerateTokenService, GenerateTokenService>();
        services.AddScoped<IIdGenerator, IdGenerator>();

        return services;
    }
}
