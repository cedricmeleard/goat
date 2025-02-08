using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Entities;

public class Weapon(WeaponName name, Damage damage)
{
    public WeaponName GetName() => name;
}