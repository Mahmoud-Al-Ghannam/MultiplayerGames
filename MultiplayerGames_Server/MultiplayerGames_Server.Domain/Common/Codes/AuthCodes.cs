using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class AuthCodes
{
    public static class Error
    {
        public const string Unauthenticated = "Auth.Error.Unauthenticated";
        public const string InvalidEmailOrPassword = "Auth.Error.InvalidEmailOrPassword";
        public const string InvalidPassword = "Auth.Error.InvalidPassword";
        public const string EmailNotVerified = "Auth.Error.EmailNotVerified";
        public const string OtpIsNotForThatUser = "Auth.Error.OtpIsNotForThatUser";
        public const string InvalidEmailOrOtp = "Auth.Error.InvalidEmailOrOtp";
        public const string EmailAlreadyConfirmed = "Auth.Error.EmailAlreadyConfirmed";
        public const string InvalidEmailOrToken = "Auth.Error.InvalidEmailOrToken";
        public const string InvalidEmail = "Auth.Error.InvalidEmail";
        public const string InvalidCredentials = "Auth.Error.InvalidCredentials";
    }

    public static class Success
    {
        public const string LoginSuccess = "Auth.Success.LoginSuccess";
        public const string RegistrationSuccess = "Auth.Success.RegistrationSuccess";
        public const string PasswordChanged = "Auth.Success.PasswordChanged";
        public const string EmailConfirmed = "Auth.Success.EmailConfirmed";
        public const string RefreshTokenSuccess = "Auth.Success.RefreshTokenSuccess";
        public const string ResentOtpCode = "Auth.Success.ResentOtpCode";
        public const string ForgotPasswordOtpSent = "Auth.Success.ForgotPasswordOtpSent";
        public const string PasswordReset = "Auth.Success.PasswordReset";
    }
}
