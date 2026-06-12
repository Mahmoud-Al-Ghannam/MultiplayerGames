using System;
using OnlineXO_Server.Application.Broadcasters.XOGame;

namespace OnlineXO_Server.Infrastructure.SignalR.Hubs.XOGameHub;

public interface IXOGameHubClient
{
    public Task GameCreatedAsync(GameDto gameDto);
    public Task GameDeletedAsync(string gameId);
    public Task GameUpdatedAsync(GameDto gameDto);
}
