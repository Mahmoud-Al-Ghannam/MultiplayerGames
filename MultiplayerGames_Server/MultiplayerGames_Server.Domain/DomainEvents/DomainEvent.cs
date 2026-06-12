using System;
using MultiplayerGames_Server.Domain.Abstractions;

namespace MultiplayerGames_Server.Domain.DomainEvents;

public class DomainEvent : IDomainEvent
{
    public DateTime OccurredAt { get; protected set; } = DateTime.UtcNow;
}
