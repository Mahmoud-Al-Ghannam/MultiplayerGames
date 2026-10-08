using System;

namespace MultiplayerGames_Server.Domain.Common;

public static class ValidationPatterns
{
    // Email pattern
    public const string Email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    // Phone number pattern (international format)
    public const string PhoneNumber = @"^\+?[1-9]\d{1,14}$";

    // Name pattern (allows letters, spaces, hyphens, and apostrophes)
    public const string Name = @"^[a-zA-Z\s'-]+$";
    public const string NameOptional = @"^[a-zA-Z\s'-]*$";

    // Password pattern (must contain at least one lowercase, one uppercase, and one digit)
    public const string PasswordComplexity = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)";

    // OTP pattern (only digits)
    public const string OtpCode = @"^\d{6}$";
}
