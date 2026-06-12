using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MultiplayerGames_Server.Infrastructure.SignalR.DataModels;

public class HubGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
