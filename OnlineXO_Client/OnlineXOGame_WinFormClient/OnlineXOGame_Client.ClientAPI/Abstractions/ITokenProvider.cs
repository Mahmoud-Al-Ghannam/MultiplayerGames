using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Abstractions {
    public interface ITokenProvider {
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken);
        public Task SetAccessTokenAsync(string token, CancellationToken cancellationToken);
    }
}
