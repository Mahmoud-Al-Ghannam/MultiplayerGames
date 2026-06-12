using System;
using MultiplayerGames_Server.Domain.Common;

namespace MultiplayerGames_Server.Domain.Aggregates.Test;

public class Test : AggregateRoot
{
    public int Id { get; set; }
    public int Counter { get; set; }
}
