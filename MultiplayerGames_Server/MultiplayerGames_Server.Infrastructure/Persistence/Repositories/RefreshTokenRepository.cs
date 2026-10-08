using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;
using MultiplayerGames_Server.Domain.Aggregates.RefreshToken;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Repositories;

internal class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }

    public async Task<IEnumerable<RefreshToken>> GetAllActiveTokensByUserIdAsync(
        string userId,
        CancellationToken cancellationToken
    )
    {
        return await _dbSet.Where(rt => rt.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task<RefreshToken?> GetByHashedTokenAndUserIdAsync(
        string hashedToken,
        string userId,
        CancellationToken cancellationToken
    )
    {
        return await _dbSet.FirstOrDefaultAsync(
            rt => rt.HashedToken == hashedToken && rt.UserId == userId,
            cancellationToken
        );
    }
}
