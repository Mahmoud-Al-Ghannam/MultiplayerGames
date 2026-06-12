using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineXO_Server.Application.Abstractions.Data;
using OnlineXO_Server.Application.Abstractions.Data.ReadRepository;
using OnlineXO_Server.Application.Abstractions.Services;
using OnlineXO_Server.Application.Broadcasters.XOGame;
using OnlineXO_Server.Domain.Abstractions;
using OnlineXO_Server.Infrastructure.Options;
using OnlineXO_Server.Infrastructure.Persistence.Data;
using OnlineXO_Server.Infrastructure.Persistence.ReadRepositories;
using OnlineXO_Server.Infrastructure.Services;

namespace OnlineXO_Server.Infrastructure.DependencyInjection;

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
            configuration.GetConnectionString("DefaultConnection") ?? "Data Source=xo-game.db"; // fallback

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString).EnableDetailedErrors(true)
        );

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
