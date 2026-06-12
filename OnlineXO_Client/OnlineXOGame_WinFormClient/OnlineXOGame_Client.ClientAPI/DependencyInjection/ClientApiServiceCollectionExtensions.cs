using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.ApiClients;
using OnlineXOGame_Client.ClientAPI.Common.Extensions;
using OnlineXOGame_Client.ClientAPI.Common.Handlers;
using OnlineXOGame_Client.ClientAPI.Common.Options;
using OnlineXOGame_Client.ClientAPI.Facade;
using OnlineXOGame_Client.ClientAPI.HubClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.HubClient.HubClients;
using OnlineXOGame_Client.ClientAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.DependencyInjection {
    public static class ClientApiServiceCollectionExtensions {
        public static IServiceCollection AddClientApi(this IServiceCollection services,IConfiguration configuration) {
            services.Configure<ClientOptions>(options =>
                configuration.GetSection("ClientOptions").Bind(options)
            );

            services.AddSingleton<ITokenProvider,TokenProvider>();
            services.AddSingleton<IKeyValueStorage,KeyValueStorage>();
            services.AddSingleton<ICurrentUserSession,CurrentUserSession>();


            services.AddTransient<AuthHeaderHandler>();
            services.AddTransient<ApiErrorHandler>();

            services.AddCustomHttpClient<IAuthApiClient,AuthApiClient>(configuration);
            services.AddCustomHttpClient<IUserApiClient,UserApiClient>(configuration);
            services.AddCustomHttpClient<IXOGameApiClient,XOGameApiClient>(configuration);

            services.AddScoped<IXOGameHubClient,XOGameHubClient>();
            services.AddScoped<IXOGameFacade,XOGameFacade>();
            return services;
        }

        public static IServiceCollection AddCustomHttpClient<TClient, TImplementation> (this IServiceCollection services,IConfiguration configuration) where TClient : class where TImplementation : class, TClient {
            
            services.AddHttpClient<TClient,TImplementation>()
                .ConfigureDefaultApiClient(configuration)
                .AddHttpMessageHandler<AuthHeaderHandler>()
                .AddHttpMessageHandler<ApiErrorHandler>();

            return services;
        }
    }
}
