using System;
using Microsoft.AspNetCore.SignalR;
using MultiplayerGames_Server.Application.Broadcasters.XOGame;
using MultiplayerGames_Server.Infrastructure.SignalR.Common.Constants;
using MultiplayerGames_Server.Infrastructure.SignalR.Hubs.XOGameHub;

namespace MultiplayerGames_Server.Infrastructure.SignalR.Services.Broadcasters;

public class XOGameBroadcaster : IXOGameBroadcaster
{
    private readonly IHubContext<XOGameHub, IXOGameHubClient> _hubContext;

    public XOGameBroadcaster(IHubContext<XOGameHub, IXOGameHubClient> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task GameCreatedAsync(GameDto game, CancellationToken cancellationToken)
    {
        await _hubContext.Clients.Group(HubConstants.XOGameHub.Groups.Lobby).GameCreatedAsync(game);
    }

    public async Task GameDeletedAsync(string gameId, CancellationToken cancellationToken)
    {
        await _hubContext
            .Clients.Group(HubConstants.XOGameHub.Groups.Lobby)
            .GameDeletedAsync(gameId);

        await _hubContext
            .Clients.Group(HubConstants.XOGameHub.Groups.GameRoom(gameId))
            .GameDeletedAsync(gameId);
    }

    public async Task GameUpdatedAsync(GameDto game, CancellationToken cancellationToken)
    {
        await _hubContext.Clients.Group(HubConstants.XOGameHub.Groups.Lobby).GameUpdatedAsync(game);

        await _hubContext
            .Clients.Group(HubConstants.XOGameHub.Groups.GameRoom(game.Id))
            .GameUpdatedAsync(game);
    }
}
