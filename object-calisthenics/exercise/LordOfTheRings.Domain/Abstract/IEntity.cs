namespace LordOfTheRings.Domain.Abstract;

public interface IEntity
{
    void RaiseEvent<T>(T domainEvent) where T : IDomainEvent;
}