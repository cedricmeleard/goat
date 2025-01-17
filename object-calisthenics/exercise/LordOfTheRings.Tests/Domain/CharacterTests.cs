using System;
using FluentAssertions;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Tests.Domain;

public class CharacterTests
{
    [Fact]
    public void CharacterCantReturnFromMordor()
    {
        // Arrange
        var frodo = Character.Create(Name.Parse("Frodo Baggins"), Race.Hobbit, new Weapon(WeaponName.Parse("Dard"), Damage.Parse(100)));
        frodo.ChangeRegion(Region.Mordor);

        // Act
        var action = () => frodo.ChangeRegion(Region.Shire);

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot move Frodo Baggins from Mordor to Shire. Reason: There is no coming back from Mordor.");
    }
}