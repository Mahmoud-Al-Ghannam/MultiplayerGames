using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerGames_Server.Application.Abstractions.Data.ReadRepository;
using MultiplayerGames_Server.Application.Common.Behaviors;
using MultiplayerGames_Server.Application.UseCases.Test;
using MultiplayerGames_Server.Application.UseCases.User;
using MultiplayerGames_Server.Application.UseCases.XOGame;

namespace MultiplayerGames_Server.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        //services.AddAutoMapper(assembly);
        //services.AddValidatorsFromAssembly(assembly);

        // Register Pipeline Behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<XOGameService>();
        services.AddScoped<TestService>();
        return services;
    }
}
