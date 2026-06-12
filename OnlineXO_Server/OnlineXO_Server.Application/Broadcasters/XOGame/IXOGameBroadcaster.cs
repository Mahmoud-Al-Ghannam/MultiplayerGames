using System;

namespace OnlineXO_Server.Application.Broadcasters.XOGame;

public interface IXOGameBroadcaster
{
    Task GameUpdatedAsync(GameDto game, CancellationToken cancellationToken);
    Task GameCreatedAsync(GameDto game, CancellationToken cancellationToken);
    Task GameDeletedAsync(string gameId, CancellationToken cancellationToken);
}
