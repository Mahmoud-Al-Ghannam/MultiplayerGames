using System;
using OnlineXO_Server.Application.UseCases.XOGame.RequestDTOs;
using OnlineXO_Server.Application.UseCases.XOGame.ResponseDTOs;
using OnlineXO_Server.Domain.Aggregates.XOGame;

namespace OnlineXO_Server.Application.Abstractions.Data.ReadRepository;

public interface IGameReadRepository
{
    Task<IEnumerable<GameItemDto>> GetGamesAsync(
        GetGamesQueryDto query,
        CancellationToken cancellationToken
    );
}
