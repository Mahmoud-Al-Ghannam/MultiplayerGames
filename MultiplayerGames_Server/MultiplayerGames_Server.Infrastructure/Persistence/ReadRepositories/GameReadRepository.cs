using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Data.ReadRepository;
using MultiplayerGames_Server.Application.UseCases.XOGame.RequestDTOs;
using MultiplayerGames_Server.Application.UseCases.XOGame.ResponseDTOs;
using MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame;
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

        if (query.WinnerName != null)
        {
            q = q.Where(g =>
                _dbContext.Users.Any(u =>
                    u.Username.Contains(query.WinnerName)
                    && (
                        (g.Player1Id == u.Id && g.Winner == PlayerNumber.P1)
                        || (g.Player2Id == u.Id && g.Winner == PlayerNumber.P2)
                    )
                )
            );
        }

        return await q.Select(g => new GameItemDto
            {
                Id = g.Id,
                Player2Id = g.Player2Id,
                Player1Id = g.Player1Id,
                Player2 = _dbContext
                    .Users.Where(u => u.Id == g.Player2Id)
                    .Select(u => u.Username)
                    .FirstOrDefault(),
                Player1 = _dbContext
                    .Users.Where(u => u.Id == g.Player1Id)
                    .Select(u => u.Username)
                    .FirstOrDefault(),
                CurrentTurn = g.CurrentTurn.ToString(),
                Winner = g.Winner.ToString(),
                Status = g.Status.ToString(),
            })
            .ToListAsync(cancellationToken);
    }
}
