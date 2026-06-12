using System;
using System.Data;

namespace MultiplayerGames_Server.Domain.Common.Codes;

public static class XOGameCodes
{
    public static class Error
    {
        public const string NotFound = "XOGame.Error.NotFound";
        public const string Finished = "XOGame.Error.Finished";
        public const string PlayerXIdRequired = "XOGame.Error.PlayerXIdRequired";
        public const string PlayerOIdRequired = "XOGame.Error.PlayerOIdRequired";
        public const string AlreadyStartedOrFinished = "XOGame.Error.AlreadyStartedOrFinished";
        public const string AlreadyFinished = "XOGame.Error.AlreadyFinished";
        public const string NotInProgress = "XOGame.Error.NotInProgress";

        public const string NotPlayerTurn = "XOGame.Error.NotPlayerTurn";
        public const string NotPlayer = "XOGame.Error.NotPlayer";
        public const string AlreadyPlayer = "XOGame.Error.AlreadyPlayer";

        public static class Board
        {
            public const string InvalidPosition = "XOGame.Error.Board.InvalidPosition";
            public const string CellAlreadyOccupied = "XOGame.Error.Board.CellAlreadyOccupied";
        }
    }

    public static class Success
    {
        public const string Retrived = "XOGame.Success.Retrived";
        public const string Created = "XOGame.Success.Created";
        public const string Updated = "XOGame.Success.Updated";
        public const string Deleted = "XOGame.Success.Deleted";
        public const string PlayerJoind = "XOGame.Success.PlayerJoind";
        public const string PlayerLeft = "XOGame.Success.PlayerLeft";
        public const string MadeMove = "XOGame.Success.MadeMove";
    }
}
