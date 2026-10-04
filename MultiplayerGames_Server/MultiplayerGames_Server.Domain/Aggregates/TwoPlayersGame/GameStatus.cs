namespace MultiplayerGames_Server.Domain.Aggregates.TwoPlayersGame;

public enum GameStatus : byte
{
    WaitingForPlayers = 0,
    InProgress = 1,
    Finished = 2,
}
