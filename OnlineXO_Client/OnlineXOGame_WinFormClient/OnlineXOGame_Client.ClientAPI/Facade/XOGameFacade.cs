using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame;
using OnlineXOGame_Client.ClientAPI.Common.Enums;
using OnlineXOGame_Client.ClientAPI.HubClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.HubClient.DTOs.XOGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Facade {
    internal class XOGameFacade : IXOGameFacade {

        public event Action<GameDto>? GameCreatedAsync;
        public event Action<string>? GameDeletedAsync;
        public event Action<GameDto>? GameUpdatedAsync;

        private readonly IXOGameApiClient _apiClient;
        private readonly IXOGameHubClient _hubClient;

        public XOGameFacade(IXOGameApiClient apiClient,IXOGameHubClient hubClient) {
            _apiClient = apiClient;
            _hubClient = hubClient;

            _hubClient.GameCreatedAsync += (game) => GameCreatedAsync?.Invoke(game);
            _hubClient.GameDeletedAsync += (gameId) => GameDeletedAsync?.Invoke(gameId);
            _hubClient.GameUpdatedAsync += (game) => GameUpdatedAsync?.Invoke(game);
        }

        public async Task<BaseResponseDto<string>> CreateGameAsync(CancellationToken ct) {
            return await _apiClient.CreateGameAsync(ct);
        }

        public async Task<BaseResponseDto<GameInfoDto>> GetGameAsync(string gameId,CancellationToken ct) {
            return await _apiClient.GetGameAsync(gameId,ct);
        }

        public async Task<BaseResponseDto<IEnumerable<GameItemDto>>> GetGamesAsync(GameStatus? status = null,string? winner = null, CancellationToken ct=default) {
            return await _apiClient.GetGamesAsync(status,winner, ct);
        }

        public async Task<BaseResponseDto<object>> JoinGameAsync(string gameId,CancellationToken ct) {
            return await _apiClient.JoinGameAsync(gameId,ct);
        }

        public async Task<BaseResponseDto<object>> LeaveGameAsync(string gameId,CancellationToken ct) {
            return await _apiClient.LeaveGameAsync(gameId,ct);
        }


        public async Task JoinGameRoomAsync(string gameId) {
            await _hubClient.JoinGameRoomAsync(gameId);
        }
        public async Task JoinLobbyAsync() {
            await _hubClient.JoinLobbyAsync();
        }
        public async Task LeaveGameRoomAsync(string gameId) {
            await _hubClient.LeaveGameRoomAsync(gameId);
        }

        public async Task LeaveLobbyAsync() {
            await _hubClient.LeaveLobbyAsync();
        }

        public async Task MakeMoveAsync(string gameId,int row,int col) {
            await _hubClient.MakeMoveAsync(gameId,row,col);
        }
    }
}
