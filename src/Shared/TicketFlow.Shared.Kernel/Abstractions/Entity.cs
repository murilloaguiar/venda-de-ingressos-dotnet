using TicketFlow.Shared.Kernel.Events;

namespace TicketFlow.Shared.Kernel.Abstractions;
public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }

    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
