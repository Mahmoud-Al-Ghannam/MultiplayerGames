using System;
using System.Reflection;
using Dorssel.EntityFrameworkCore;
using Hangfire;
using Hangfire.Community.Outbox.Extensions;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerGames_Server.Application.Abstractions.Data;
using MultiplayerGames_Server.Application.Abstractions.Data.ReadRepository;
using MultiplayerGames_Server.Application.Abstractions.Services;
using MultiplayerGames_Server.Application.Broadcasters.XOGame;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
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
        IWebHostEnvironment environment,
        IConfiguration configuration
    )
    {
        services.Configure<JwtOptions>(options =>
            configuration.GetSection("JwtOptions").Bind(options)
        );
        services.Configure<EmailOptions>(options =>
            configuration.GetSection("EmailSettings").Bind(options)
        );

        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found."
            );

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString).EnableDetailedErrors(true);
        });

        services.AddHangfireOutbox<ApplicationDbContext>();
        // Add Hangfire services.
        services.AddHangfire(configuration =>
            configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(
                    connectionString,
                    new SqlServerStorageOptions { SchemaName = "Hangfire" }
                )
        );
        // Add the processing server as IHostedService
        services.AddHangfireServer();

        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGameReadRepository, GameReadRepository>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IGenerateTokenService, GenerateTokenService>();
        services.AddScoped<IIdGenerator, IdGenerator>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IOtpCodeHasher, OtpCodeHasher>();
        services.AddScoped<IRefreshTokenHasher, RefreshTokenHasher>();

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();
        services.AddScoped<IFileStorageService, FileStorageService>();
        services.AddScoped<IOtpService, OtpService>();

        return services;
    }
}
