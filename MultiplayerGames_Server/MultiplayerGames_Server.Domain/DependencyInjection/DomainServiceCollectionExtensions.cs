using System;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerGames_Server.Domain.Abstractions.DomainServices;
using MultiplayerGames_Server.Domain.Services;

namespace MultiplayerGames_Server.Domain.DependencyInjection;

public static class DomainServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IConfirmUserEmailService, ConfirmUserEmailService>();
        services.AddScoped<IResetUserPasswordService, ResetUserPasswordService>();

        return services;
    }
}
