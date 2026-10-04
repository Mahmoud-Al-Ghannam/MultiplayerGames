using System;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public class TwoPlayersGameCodes
{
    public static class Error
    {
        public const string NotFound = "TwoPlayersGame.Error.NotFound";
        public const string Finished = "TwoPlayersGame.Error.Finished";
        public const string Player1IdRequired = "TwoPlayersGame.Error.Player1IdRequired";
        public const string Player2IdRequired = "TwoPlayersGame.Error.Player2IdRequired";
        public const string AlreadyStartedOrFinished =
            "TwoPlayersGame.Error.AlreadyStartedOrFinished";
        public const string AlreadyFinished = "TwoPlayersGame.Error.AlreadyFinished";
        public const string NotInProgress = "TwoPlayersGame.Error.NotInProgress";
        public const string NotPlayer = "TwoPlayersGame.Error.NotPlayer";
        public const string AlreadyPlayer = "TwoPlayersGame.Error.AlreadyPlayer";
    }

    public static class Success
    {
        public const string Retrived = "TwoPlayersGame.Success.Retrived";
        public const string Created = "TwoPlayersGame.Success.Created";
        public const string Updated = "TwoPlayersGame.Success.Updated";
        public const string Deleted = "TwoPlayersGame.Success.Deleted";
        public const string PlayerJoind = "TwoPlayersGame.Success.PlayerJoind";
        public const string PlayerLeft = "TwoPlayersGame.Success.PlayerLeft";
    }
}
