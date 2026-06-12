using System;
using OnlineXO_Server.Domain.Abstractions;

namespace OnlineXO_Server.Domain.DomainEvents;

public class DomainEvent : IDomainEvent
{
    public DateTime OccurredAt { get; protected set; } = DateTime.UtcNow;
}
