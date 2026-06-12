using System;
using Microsoft.Extensions.DependencyInjection;

namespace MultiplayerGames_Server.Domain.DependencyInjection;

public static class DomainServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
