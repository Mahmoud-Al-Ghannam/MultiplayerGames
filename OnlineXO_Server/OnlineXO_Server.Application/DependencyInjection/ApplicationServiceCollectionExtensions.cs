using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineXO_Server.Application.Abstractions.Data.ReadRepository;
using OnlineXO_Server.Application.Common.Behaviors;
using OnlineXO_Server.Application.UseCases.User;
using OnlineXO_Server.Application.UseCases.XOGame;

namespace OnlineXO_Server.Application.DependencyInjection;

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
        return services;
    }
}
