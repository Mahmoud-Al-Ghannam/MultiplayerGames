namespace MultiplayerGames_Server.Domain.Abstractions.Services;

public interface IRefreshTokenHasher : IHasher
{
    bool Verify(string token, string hashedToken);
}
