using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using OnlineXO_Server.Infrastructure.Options;

namespace OnlineXOServer.WebApi.DependencyInjection;

public static class WebapiServiceCollectionExtensions
{
    public static IServiceCollection AddWebapi(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddControllers();
        services.AddOpenApi(
            "v1",
            options =>
            {
                options.AddDocumentTransformer(
                    (
                        (document, context, ct) =>
                        {
                            // Add the Bearer scheme definition
                            document.Components ??= new OpenApiComponents();
                            document.Components.SecuritySchemes ??=
                                new Dictionary<string, IOpenApiSecurityScheme>();
                            document.Components.SecuritySchemes["Bearer"] =
                                new OpenApiSecurityScheme
                                {
                                    Type = SecuritySchemeType.Http,
                                    Scheme = "bearer",
                                    BearerFormat = "JWT",
                                };

                            return Task.CompletedTask;
                        }
                    )
                );
            }
        );

        services.AddHttpContextAccessor();

        JwtOptions jwtOptions =
            configuration.GetSection("JwtOptions").Get<JwtOptions>()
            ?? throw new Exception("Cannot load jwt options data");

        // Add JWT Authentication
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Key)
                    ),
                };

                // 👇 This is the crucial part for SignalR
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    },
                };
            });

        return services;
    }
}
