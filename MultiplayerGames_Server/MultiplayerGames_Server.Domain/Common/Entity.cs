using System;
using MultiplayerGames_Server.Domain.Abstractions;

namespace MultiplayerGames_Server.Domain.Common;

public abstract class Entity
{
    public string Id { get; protected set; } = string.Empty;

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id == entity.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
