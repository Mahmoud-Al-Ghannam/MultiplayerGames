using System;
using MultiplayerGames_Server.Application.UseCases.XOGame.RequestDTOs;
using MultiplayerGames_Server.Application.UseCases.XOGame.ResponseDTOs;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;

namespace MultiplayerGames_Server.Application.Abstractions.Data.ReadRepository;

public interface IGameReadRepository
{
    Task<IEnumerable<GameItemDto>> GetGamesAsync(
        GetGamesQueryDto query,
        CancellationToken cancellationToken
    );
}
