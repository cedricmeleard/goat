using System;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Entities;

public sealed class Character
{
    private readonly Name _name;
    private readonly Race _race;
    private Region _region = Region.Shire;
    private Weapon _weapon;
    private Character(Name name, Race race, Weapon weapon)
    {
        _name = name;
        _race = race;
        _weapon = weapon;
    }

    public Name GetName() => _name;
    public Race GetRace() => _race;
    public WeaponName GetWeaponName() => _weapon.GetName();
    public Region GetRegion() => _region;

    public static Character Create(Name name, Race race, Weapon weapon)
    {
        if (weapon is null) {
            throw new ArgumentException("Character must have a weapon.");
        }

        return new Character(name, race, weapon);
    }

    public bool IsFromRegion(Region region) => _region == region;

    public void ChangeWeapon(Weapon newWeapon) => _weapon = newWeapon;
    public void ChangeRegion(Region region)
    {
        if (GetRegion() == Region.Mordor && region != Region.Mordor) {
            throw new InvalidOperationException($"Cannot move {GetName()} from Mordor to {region}. Reason: There is no coming back from Mordor.");
        }
        _region = region;

        // let's see if that can be moved to domain events
        Console.WriteLine(region != Region.Mordor ? $"{_name} moved to {region}." : $"{_name} moved to {region} 💀.");
    }
}