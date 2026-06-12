using System;

namespace MultiplayerGames_Server.Infrastructure.SignalR.DataModels;

public class HubGroupUser
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
