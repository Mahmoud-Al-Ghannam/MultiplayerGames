using System;
using MultiplayerGames_Server.Domain.Aggregates.RefreshToken;

namespace MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
{
    public Task<RefreshToken?> GetByHashedTokenAndUserIdAsync(
        string hashedToken,
        string userId,
        CancellationToken cancellationToken
    );
    public Task<IEnumerable<RefreshToken>> GetAllActiveTokensByUserIdAsync(
        string userId,
        CancellationToken cancellationToken
    );
}
