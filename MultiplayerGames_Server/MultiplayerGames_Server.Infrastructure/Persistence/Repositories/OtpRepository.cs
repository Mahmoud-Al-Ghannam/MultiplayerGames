using System;
using Microsoft.EntityFrameworkCore;
using MultiplayerGames_Server.Application.Abstractions.Data.Repositories;
using MultiplayerGames_Server.Domain.Aggregates.Otp;
using MultiplayerGames_Server.Infrastructure.Persistence.Data;

namespace MultiplayerGames_Server.Infrastructure.Persistence.Repositories;

internal class OtpRepository : BaseRepository<Otp>, IOtpRepository
{
    public OtpRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }

    public async Task<IEnumerable<Otp>> GetAllUsableOtpsByUserIdAsync(
        string userId,
        CancellationToken cancellationToken
    )
    {
        var otps = await _dbSet
            .Where(x =>
                x.UserId == userId && !x.IsUsed && x.IsActive && x.ExpiredAtUtc > DateTime.UtcNow
            )
            .OrderByDescending(x => x.CreatedAtUtc)
            .ToListAsync(cancellationToken);

        return otps;
    }

    public Task<Otp?> GetByCodeHashAndUserIdAsync(
        string hashedOtpCode,
        string userId,
        CancellationToken cancellationToken = default
    )
    {
        return _dbSet.FirstOrDefaultAsync(
            x => x.HashedOtpCode == hashedOtpCode && x.UserId == userId,
            cancellationToken
        );
    }
}
