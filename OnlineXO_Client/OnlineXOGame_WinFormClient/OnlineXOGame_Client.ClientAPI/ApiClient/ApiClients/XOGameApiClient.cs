using OnlineXOGame_Client.ClientAPI.ApiClient.Abstractions;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs;
using OnlineXOGame_Client.ClientAPI.ApiClient.DTOs.XOGame;
using OnlineXOGame_Client.ClientAPI.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.ApiClient.ApiClients {
    internal class XOGameApiClient : BaseApiClient, IXOGameApiClient {

        public static class Endpoints {
            public static string Controller => "xo-games";
            public static string GetGames(GameStatus? gameStatus,string? winner) {
                string url = $"{PrefixApiPath.TrimEnd('/')}/{Controller}";
                List<string> queryParams = new List<string>();
                if(gameStatus != null || !string.IsNullOrEmpty(winner)) {
                    url += "?";
                    if(gameStatus != null) {
                        queryParams.Add($"Status={(byte) gameStatus}");
                    }
                    if(!string.IsNullOrEmpty(winner)) {
                        queryParams.Add($"winner={winner}");
                    }
                    url += string.Join("&", queryParams);
                }
                return url;
            }
            public static string GetGame(string gameId) => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/{gameId}";
            public static string CreateGame => $"{PrefixApiPath.TrimEnd('/')}/{Controller}";
            public static string JoinGame(string gameId) => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/{gameId}/join";
            public static string LeaveGame(string gameId) => $"{PrefixApiPath.TrimEnd('/')}/{Controller}/{gameId}/leave";
        }
        public XOGameApiClient(HttpClient httpClient) : base(httpClient) {
        }

        public async Task<BaseResponseDto<string>> CreateGameAsync(CancellationToken ct) {
           return await PostAsync<BaseResponseDto<string>>(Endpoints.CreateGame,ct);
        }

        public async Task<BaseResponseDto<GameInfoDto>> GetGameAsync(string gameId,CancellationToken ct) {
            return await GetAsync<BaseResponseDto<GameInfoDto>>(Endpoints.GetGame(gameId),ct);
        }

        public async Task<BaseResponseDto<IEnumerable<GameItemDto>>> GetGamesAsync(GameStatus? status = null,string? winner = null, CancellationToken ct = default) {
            return await GetAsync<BaseResponseDto<IEnumerable<GameItemDto>>>(Endpoints.GetGames(status, winner),ct);
        }

        public async Task<BaseResponseDto<object>> JoinGameAsync(string gameId,CancellationToken ct) {
            return await PostAsync<BaseResponseDto<object>>(Endpoints.JoinGame(gameId),ct);
        }

        public async Task<BaseResponseDto<object>> LeaveGameAsync(string gameId,CancellationToken ct) {
            return await PostAsync<BaseResponseDto<object>>(Endpoints.LeaveGame(gameId),ct);
        }
    }
}
