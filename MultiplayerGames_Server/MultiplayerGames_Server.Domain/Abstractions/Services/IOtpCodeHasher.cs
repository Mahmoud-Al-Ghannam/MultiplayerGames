namespace MultiplayerGames_Server.Domain.Abstractions.Services;

public interface IOtpCodeHasher : IHasher
{
    bool Verify(string otp, string hashedOtp);
}
