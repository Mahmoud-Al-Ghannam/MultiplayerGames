using System;
using MultiplayerGames_Server.Domain.Abstractions;
using MultiplayerGames_Server.Domain.Abstractions.Services;
using MultiplayerGames_Server.Domain.Common;
using MultiplayerGames_Server.Domain.Common.Codes;
using MultiplayerGames_Server.Domain.Common.Exceptions;

namespace MultiplayerGames_Server.Domain.Aggregates.RefreshToken;

public class RefreshToken : AggregateRoot
{
    public string UserId { get; private set; }
    public string HashedToken { get; private set; }
    public DateTime ExpiresAtUtc { get; private set; }
    public DateTime? RevokedAtUtc { get; private set; }
    public string? ReplacedByTokenId { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    private RefreshToken() { }

    public static RefreshToken Create(
        string userId,
        string token,
        TimeSpan lifetime,
        IIdGenerator idGenerator,
        IRefreshTokenHasher refreshTokenHasher
    )
    {
        userId = userId?.Trim() ?? string.Empty;
        token = token?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(userId))
            throw new DomainException(RefreshTokenCodes.Error.UserId.Required);
        if (string.IsNullOrEmpty(token))
            throw new DomainException(RefreshTokenCodes.Error.Token.Required);

        return new RefreshToken
        {
            Id = idGenerator.NewId(),
            UserId = userId,
            HashedToken = refreshTokenHasher.Hash(token),
            ExpiresAtUtc = DateTime.UtcNow.Add(lifetime),
            CreatedAtUtc = DateTime.UtcNow,
        };
    }

    public void Replace(string replacedByTokenId)
    {
        if (string.IsNullOrEmpty(replacedByTokenId))
            throw new DomainException(RefreshTokenCodes.Error.ReplaceByToken.Required);

        RevokedAtUtc = DateTime.UtcNow;
        ReplacedByTokenId = replacedByTokenId;
    }

    public void Revoke()
    {
        RevokedAtUtc = DateTime.UtcNow;
    }
}
