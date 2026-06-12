using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineXOGame_Client.ClientAPI.Common.Enums {
    public enum GameStatus : byte {
        WaitingForPlayers = 0,
        InProgress = 1,
        Finished = 2,
    }
}
