using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame;
using OnlineXOGame_Client.ClientAPI.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions {
    public interface IXOGameApiClient {

        public Task<BaseResponseDto<string>> CreateGameAsync(CancellationToken ct);
        public Task<BaseResponseDto<object>> JoinGameAsync(string gameId,CancellationToken ct);
        public Task<BaseResponseDto<object>> LeaveGameAsync(string gameId,CancellationToken ct);


        public Task<BaseResponseDto<GameInfoDto>> GetGameAsync(string gameId,CancellationToken ct);
        public Task<BaseResponseDto<IEnumerable<GameItemDto>>> GetGamesAsync(GameStatus? status = null,string? winner = null,CancellationToken ct = default);

    }
}
