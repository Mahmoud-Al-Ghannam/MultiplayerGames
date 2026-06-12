using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineXOGame_Client.ClientAPI.Common.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Common.Extensions {
    internal static class HttpClientBuilderExtensions {
        public static IHttpClientBuilder ConfigureDefaultApiClient(this IHttpClientBuilder builder, IConfiguration configuration) {
            var clientOptions = configuration.GetSection("ClientOptions").Get<ClientOptions>();

            return builder.ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(clientOptions?.BaseApiUrl ?? string.Empty);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept","application/json");
            });
        }
    }
}
