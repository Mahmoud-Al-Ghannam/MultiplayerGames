using System;
using MultiplayerGames_Server.Domain.Aggregates.Otp;

namespace MultiplayerGames_Server.Application.Abstractions.Data.Repositories;

public interface IOtpRepository : IBaseRepository<Otp>
{
    public Task<IEnumerable<Otp>> GetAllUsableOtpsByUserIdAsync(
        string userId,
        CancellationToken cancellationToken
    );
    public Task<Otp?> GetByCodeHashAndUserIdAsync(
        string hashedOtpCode,
        string userId,
        CancellationToken cancellationToken
    );
}
