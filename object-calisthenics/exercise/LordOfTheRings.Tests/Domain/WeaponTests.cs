using FsCheck;
using FsCheck.Fluent;
using FsCheck.Xunit;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Tests.Domain;

public class WeaponTests
{
    /*[Property(MaxTest = 100)]
    public void AWeaponMustMakeDamage(PositiveInt damage, NonEmptyString name)
        => Prop.ForAll(
                Arb.Generate<int>().Where(i => i > 0).ToArbitrary(),
                Arb.Generate<string>().Where(s => !string.IsNullOrWhiteSpace(s)).ToArbitrary(),
                (damage, name) => Assert.NotNull(new Weapon(WeaponName.Parse(name), Damage.Parse(damage))))
            
            .QuickCheckThrowOnFailure();
            */
}