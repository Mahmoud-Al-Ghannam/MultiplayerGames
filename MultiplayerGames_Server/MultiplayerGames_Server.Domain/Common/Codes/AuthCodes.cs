using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class AuthCodes
{
    public static class Error
    {
        public const string Unauthenticated = "Auth.Error.Unauthenticated";
        public const string InvalidUsernameOrPassword = "Auth.Error.InvalidUsernameOrPassword";
    }

    public static class Success
    {
        public const string LoginSuccess = "Auth.Success.LoginSuccess";
        public const string RegistrationSuccess = "Auth.Success.RegistrationSuccess";
        public const string PasswordChanged = "Auth.Success.PasswordChanged";
    }
}
