using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Data.ReadRepository;
using MultiplayerGames_Server.Application.UseCases.XOGame.RequestDTOs;
using MultiplayerGames_Server.Application.UseCases.XOGame.ResponseDTOs;
using MultiplayerGames_Server.Domain.Aggregates.XOGame;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.Persistence.ReadRepositories;

internal class GameReadRepository : IGameReadRepository
{
    private readonly ApplicationDbContext _dbContext;

    public GameReadRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GameItemDto>> GetGamesAsync(
        GetGamesQueryDto query,
        CancellationToken cancellationToken
    )
    {
        var q = _dbContext.XOGames.AsNoTracking();

        if (query.Status != null)
            q = q.Where(g => g.Status == query.Status);

        if (query.Winner != null)
        {
            q = q.Where(g =>
                _dbContext.Users.Any(u =>
                    u.Username.Contains(query.Winner)
                    && (
                        (g.PlayerXId == u.Id && g.Winner == Mark.X)
                        || (g.PlayerOId == u.Id && g.Winner == Mark.O)
                    )
                )
            );
        }

        return await q.Select(g => new GameItemDto
            {
                Id = g.Id,
                PlayerOId = g.PlayerOId,
                PlayerXId = g.PlayerXId,
                PlayerO = _dbContext
                    .Users.Where(u => u.Id == g.PlayerOId)
                    .Select(u => u.Username)
                    .FirstOrDefault(),
                PlayerX = _dbContext
                    .Users.Where(u => u.Id == g.PlayerXId)
                    .Select(u => u.Username)
                    .FirstOrDefault(),
                CurrentTurn = g.CurrentTurn.ToString(),
                Winner = g.Winner.ToString(),
                Status = g.Status.ToString(),
            })
            .ToListAsync(cancellationToken);
    }
}
