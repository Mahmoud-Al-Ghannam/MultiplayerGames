using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineXOGame_Client.ClientAPI.Abstractions;
using OnlineXOGame_Client.ClientAPI.Common.Options;
using OnlineXOGame_Client.ClientAPI.HubClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.HubClient.DTOs.XOGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.HubClient.HubClients {
    internal class XOGameHubClient : BaseHubClient, IXOGameHubClient {

        public event Action<GameDto>? GameCreatedAsync;
        public event Action<string>? GameDeletedAsync;
        public event Action<GameDto>? GameUpdatedAsync;

        public XOGameHubClient(IOptions<ClientOptions> options,ITokenProvider tokenProvider)
        : base($"{options.Value.BaseApiUrl}/hubs/xo-games",tokenProvider) {

            RegisterHandler<GameDto>("GameCreatedAsync",dto => GameCreatedAsync?.Invoke(dto));
            RegisterHandler<GameDto>("GameUpdatedAsync",dto => GameUpdatedAsync?.Invoke(dto));
            RegisterHandler<string>("GameDeletedAsync",gameId => GameDeletedAsync?.Invoke(gameId));
        }

        public async Task JoinGameRoomAsync(string gameId) {
            await EnsureStartedAsync();
            await _connection.InvokeAsync(nameof(JoinGameRoomAsync),gameId);
        }

        public async Task JoinLobbyAsync() {
            await EnsureStartedAsync();
            await _connection.InvokeAsync(nameof(JoinLobbyAsync));
        }

        public async Task LeaveGameRoomAsync(string gameId) {
            await EnsureStartedAsync();
            await _connection.InvokeAsync(nameof(LeaveGameRoomAsync),gameId);
        }

        public async Task LeaveLobbyAsync() {
            await EnsureStartedAsync();
            await _connection.InvokeAsync(nameof(LeaveGameRoomAsync));
        }

        public async Task MakeMoveAsync(string gameId,int row,int col) {
            await EnsureStartedAsync();
            await _connection.InvokeAsync(nameof(MakeMoveAsync),gameId,row,col);
        }
    }
}
