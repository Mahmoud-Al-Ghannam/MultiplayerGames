using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class EmailCodes
{
    public static class Error
    {
        public const string Required = "Email.Error.Required";
        public const string InvalidFormat = "Email.Error.InvalidFormat";
    }

    public static class Success { }
}
