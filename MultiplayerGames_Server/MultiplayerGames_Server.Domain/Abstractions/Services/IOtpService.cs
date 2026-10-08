namespace MultiplayerGames_Server.Domain.Abstractions.Services;

public interface IOtpService
{
    string GenerateOtpCode(int codeLength);
}
