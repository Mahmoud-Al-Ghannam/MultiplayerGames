using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using OnlineXOGame_Client.ClientAPI.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.HubClient {
    internal abstract class BaseHubClient {
        protected readonly HubConnection _connection;
        private readonly SemaphoreSlim _startLock = new(1,1);

        protected BaseHubClient(string hubUrl,ITokenProvider tokenProvider) {
            _connection = _connection = new HubConnectionBuilder()
            .WithUrl(hubUrl,opt => 
                opt.AccessTokenProvider = () => 
                    Task.FromResult(tokenProvider.GetAccessTokenAsync(default).Result)
            )
            .Build();
        }

        protected async Task EnsureStartedAsync() {
            if(_connection.State != HubConnectionState.Disconnected) return;
            await _startLock.WaitAsync();
            try {
                if(_connection.State == HubConnectionState.Disconnected) {
                    await _connection.StartAsync();
                }
            }
            finally { _startLock.Release(); }
        }

        protected void RegisterHandler<T>(string methodName,Action<T> handler)
            => _connection.On(methodName,handler);

        public async Task DisposeAsync() {
            await _connection.DisposeAsync();
        }
    }
}
