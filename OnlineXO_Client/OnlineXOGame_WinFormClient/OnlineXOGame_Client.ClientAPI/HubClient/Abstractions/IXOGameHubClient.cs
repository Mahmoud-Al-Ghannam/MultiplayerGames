using OnlineXOGame_Client.ClientAPI.HubClient.DTOs.XOGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.HubClient.Abstractions {
    public interface IXOGameHubClient {
        Task JoinLobbyAsync();
        Task LeaveLobbyAsync();
        Task JoinGameRoomAsync(string gameId);
        Task LeaveGameRoomAsync(string gameId);
        Task MakeMoveAsync(string gameId,int row,int col);

        event Action<GameDto>? GameCreatedAsync;
        event Action<string>? GameDeletedAsync;
        event Action<GameDto>? GameUpdatedAsync;
    }
}
