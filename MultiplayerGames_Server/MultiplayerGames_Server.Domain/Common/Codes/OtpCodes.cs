using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class OtpCodes
{
    public static class Error
    {
        public const string NotFound = "Otp.Error.NotFound";
        public const string InvalidPurpose = "Otp.Error.InvalidPurpose";

        // Feature.Error.X
        public static class Code
        {
            public const string Required = "Otp.Error.Code.Required";
            public const string Incorrect = "Otp.Error.Code.Incorrect";
        }

        public static class LifeTime
        {
            public const string Negative = "Otp.Error.LifeTime.Negative";
            public const string Expired = "Otp.Error.LifeTime.Expired";
        }

        public static class Purpose
        {
            public const string Invalid = "Otp.Error.Purpose.Invalid";
        }

        public static class Activation
        {
            public const string NotActive = "Otp.Error.Activation.NotActive";
        }

        public static class Usage
        {
            public const string AlreadyUsed = "Otp.Error.Usage.AlreadyUsed";
        }
    }

    public static class Success { }
}
