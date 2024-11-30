using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using LordOfTheRings.Domain;

namespace LordOfTheRings.Tests.Domain;

public class WeaponNameTests
{
    private readonly Arbitrary<string> _nonNullArbitraryString = Arb
        .Generate<string>()
        .Where(name => !string.IsNullOrWhiteSpace(name) && name.All(c => !char.IsControl(c)))
        .ToArbitrary();

    [Property(MaxTest = 10)]
    public void WeaponName_ShouldBeEquals_When_SameName()
        => Prop.ForAll(
                _nonNullArbitraryString,
                name => Assert.True(WeaponName.Parse(name) == WeaponName.Parse(name)))
            .QuickCheckThrowOnFailure();

    [Property(MaxTest = 10)]
    public void WeaponName_ShouldNotBeEqual_When_Not_SameName()
        => Prop.ForAll(
                _nonNullArbitraryString,
                _nonNullArbitraryString,
                (name, name2)
                    => (!name2.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    .Implies(WeaponName.Parse(name) != WeaponName.Parse(name2)))
            .QuickCheckThrowOnFailure();

    [Theory]
    [InlineData("a")]
    [InlineData(":\006")]
    [InlineData("~ ")]
    [InlineData("H>")]
    public void Check_Names_With_Specials_Are_Equals(string name) => Assert.True(WeaponName.Parse(name) == WeaponName.Parse(name));

    [Theory]
    [InlineData("a", "A")]
    [InlineData("test", "TeSt")]
    public void Check_Names_Is_Case_UnSensitive(string lower, string random) => Assert.True(WeaponName.Parse(lower) == WeaponName.Parse(random));

    public class Failures
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void WeaponName_ShouldFail_IfEmpty(string? param)
        {
            var act = () => WeaponName.Parse(param);
            act.Should().Throw<ArgumentException>().WithMessage("A weapon must have a name.");
        }
    }
}