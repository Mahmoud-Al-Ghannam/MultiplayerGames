using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class UserCodes
{
    public static class Error
    {
        public const string NotFound = "User.Error.NotFound";

        public static class Password
        {
            public const string Required = "User.Error.Password.Required";
            public const string Wrong = "User.Error.Password.Wrong";
        }

        public static class Username
        {
            public const string Required = "User.Error.Username.Required";
            public const string Duplicate = "User.Error.Username.Duplicate";
        }
    }

    public static class Success
    {
        public const string Retrived = "User.Success.Retrived";
    }
}
