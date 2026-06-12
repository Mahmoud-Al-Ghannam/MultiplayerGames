using System;

namespace OnlineXO_Server.Infrastructure.SignalR.Common.Constants;

public static class HubConstants
{
    public static class XOGameHub
    {
        public const string Endpoint = "/hubs/xo-games";

        public static class Groups
        {
            public const string Lobby = "lobby";

            public static string GameRoom(string gameId) => $"xo-game-{gameId}";
        }
    }
}
