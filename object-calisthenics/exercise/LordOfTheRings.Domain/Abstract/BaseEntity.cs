using System;
using LordOfTheRings.Domain.DomainEvents.Regions;

namespace LordOfTheRings.Domain.Abstract;

public abstract class BaseEntity : IEntity
{
    public void RaiseEvent<T>(T domainEvent) where T : IDomainEvent
    {
        GetHandler<T>().Handle(domainEvent);
    }
    private static IDomainEventHandler<T> GetHandler<T>() where T : IDomainEvent
    {
        if (typeof(T) == typeof(CharacterMovedToRegionDomainEvent)) {
            return (IDomainEventHandler<T>)new CharacterMovedToRegionDomainEventHandler();
        }

        throw new NotSupportedException($"No handler found for domain event type: {typeof(T).Name}");
    }
}