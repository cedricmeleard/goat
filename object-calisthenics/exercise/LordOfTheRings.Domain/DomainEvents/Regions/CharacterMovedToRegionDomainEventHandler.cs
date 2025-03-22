using System;
using LordOfTheRings.Domain.Abstract;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.DomainEvents.Regions;

public record CharacterMovedToRegionDomainEvent(Name Name, Region MovedTo) : IDomainEvent;

public class CharacterMovedToRegionDomainEventHandler : IDomainEventHandler<CharacterMovedToRegionDomainEvent>
{
    public void Handle(CharacterMovedToRegionDomainEvent domainEvent)
    {
        var nameOfCharacter = domainEvent.Name;
        var movedToRegion = domainEvent.MovedTo;

        Console.WriteLine(movedToRegion != Region.Mordor
            ? $"{nameOfCharacter} moved to {movedToRegion}."
            : $"{nameOfCharacter} moved to {movedToRegion} 💀.");
    }
}