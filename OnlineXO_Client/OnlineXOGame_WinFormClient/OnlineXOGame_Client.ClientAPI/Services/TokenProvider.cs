using OnlineXOGame_Client.ClientAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Services {
    internal class TokenProvider : ITokenProvider {
        private string? _token;
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken) {
            return Task.FromResult(_token);
        }

        public Task SetAccessTokenAsync(string token,CancellationToken cancellationToken) {
            _token = token;
            return Task.CompletedTask;
        }
    }
}
