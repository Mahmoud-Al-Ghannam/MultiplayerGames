using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace OnlineXO_Server.Infrastructure.SignalR.DataModels;

public class HubGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
