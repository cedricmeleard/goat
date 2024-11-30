namespace LordOfTheRings.Domain;

public class Weapon
{
    public Weapon(WeaponName name, Damage damage)
    {
        Name = name;
        Damage = damage;
    }

    public WeaponName Name { get; }
    public Damage Damage { get; }
}