using System.Collections;
using FluentAssertions;
using LordOfTheRings.App;

namespace LordOfTheRings.Tests;

public class GoldenMasterTests
{
    [Fact]
    public async Task Should_Resist_Refactoring()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        Program.Run();

        // Assert: Utiliser Verify pour vérifier la sortie
        string output = stringWriter.ToString();
        await Verify(output);
    }

    public class Failure
    {
        [Theory]
        [ClassData(typeof(CharacterData))]
        public void Should_Fail_When_Add_Incomplete_Member(CharacterBuilder character, Type expectedExceptionType, string expectedMessage)
        {
            var sut = new FellowshipOfTheRingService();
            // Act
            var action = () => sut.AddMember(character.Build());
            // Assert: Utiliser Verify pour vérifier la sortie
            action
                .Should()
                .Throw<Exception>()
                .Where(e => e.GetType() == expectedExceptionType)
                .WithMessage(expectedMessage);
        }

        [Fact]
        public void Should_Fail_When_Character_Added_Twice()
        {
            var sut = new FellowshipOfTheRingService();
            sut.AddMember(new CharacterBuilder("Gimli", "Dwarf", new WeaponBuilder("Axe", 15)).Build());
            // Act
            var action = () => sut.AddMember(new CharacterBuilder("Gimli", "Dwarf", new WeaponBuilder("Axe", 15)).Build());
            // Assert: Utiliser Verify pour vérifier la sortie
            action
                .Should()
                .Throw<InvalidOperationException>()
                .WithMessage("A character with the same name already exists in the fellowship.");
        }

        [Fact]
        public void Should_Fail_When_Character_Added_Is_Null()
        {
            var sut = new FellowshipOfTheRingService();
            // Act
            var action = () => sut.AddMember(null);
            // Assert: Utiliser Verify pour vérifier la sortie
            action
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Character cannot be null. (Parameter 'character')");
        }

        /// <summary>
        ///     Auto generated by ChatGPT, Need using Builder since Ctor not exist in Domain Objects (yet)
        /// </summary>
        public class CharacterData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Character with null or whitespace name
                yield return new object[]
                {
                    new CharacterBuilder(null, "Elf", new WeaponBuilder("Sword", 10)), typeof(ArgumentException), "Character must have a name."
                };
                yield return new object[]
                {
                    new CharacterBuilder("", "Elf", new WeaponBuilder("Sword", 10)), typeof(ArgumentException), "Character must have a name."
                };

                // Character with null or whitespace race
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", null, new WeaponBuilder("Sword", 10)), typeof(ArgumentException), "Character must have a race."
                };
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", "", new WeaponBuilder("Sword", 10)), typeof(ArgumentException), "Character must have a race."
                };

                // Character with null weapon
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", "Elf", null), typeof(ArgumentException), "Character must have a weapon."
                };

                // Weapon with null or whitespace name
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", "Elf", new WeaponBuilder(null, 10)), typeof(ArgumentException), "A weapon must have a name."
                };
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", "Elf", new WeaponBuilder("", 10)), typeof(ArgumentException), "A weapon must have a name."
                };

                // Weapon with non-positive damage
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", "Elf", new WeaponBuilder("Sword", 0)), typeof(ArgumentException), "A weapon must have a damage level."
                };
                yield return new object[]
                {
                    new CharacterBuilder("Legolas", "Elf", new WeaponBuilder("Sword", -5)), typeof(ArgumentException), "A weapon must have a damage level."
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class CharacterBuilder
        {
            private readonly string _name;
            private readonly string _race;
            private readonly WeaponBuilder _weapon;

            public CharacterBuilder(string name, string race, WeaponBuilder weapon)
            {
                _name = name;
                _race = race;
                _weapon = weapon;
            }

            public Character Build() => new()
            {
                N = _name,
                R = _race,
                W = _weapon?.Build()
            };
        }

        public class WeaponBuilder
        {
            private readonly int _damage;
            private readonly string _name;

            public WeaponBuilder(string name, int damage)
            {
                _name = name;
                _damage = damage;
            }
            public Weapon? Build() => new()
            {
                Name = _name,
                Damage = _damage
            };
        }
    }
}