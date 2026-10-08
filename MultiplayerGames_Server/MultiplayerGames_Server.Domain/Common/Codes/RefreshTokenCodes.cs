using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class RefreshTokenCodes
{
    public static class Error
    {
        public const string NotFound = "RefreshToken.Error.NotFound";

        public static class UserId
        {
            public const string Required = "RefreshToken.Error.UserId.Required";
        }

        public static class Token
        {
            public const string Required = "RefreshToken.Error.Token.Required";
            public const string InvalidFormat = "RefreshToken.Error.Token.InvalidFormat";
        }

        public static class ReplaceByToken
        {
            public const string Required = "RefreshToken.Error.ReplaceByToken.Required";
        }
    }

    public static class Success { }
}
