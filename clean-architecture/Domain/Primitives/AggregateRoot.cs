namespace Domain.Primitives;

public abstract class  AggregateRoot
{
    private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();

    public ICollection<DomainEvent> GetDomainEvents() => domainEvents;

    protected void Raise(DomainEvent domainEvent)
    {
        this.domainEvents.Add(domainEvent);
    }

}