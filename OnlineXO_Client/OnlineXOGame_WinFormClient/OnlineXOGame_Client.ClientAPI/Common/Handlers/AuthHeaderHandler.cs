using OnlineXOGame_Client.ClientAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Common.Handlers {
    internal class AuthHeaderHandler : DelegatingHandler {
        private readonly ITokenProvider _tokenProvider;

        public AuthHeaderHandler(ITokenProvider tokenProvider) {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,CancellationToken cancellationToken) {
            // Get the current access token (e.g., from secure storage, from a service)
            var token = await _tokenProvider.GetAccessTokenAsync(cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",token);

            return await base.SendAsync(request,cancellationToken);
        }
    }
}
