namespace LordOfTheRings.Domain;

public sealed class Character
{
    private Character(Name name, Race race, Weapon weapon)
    {
        Name = name;
        Race = race;
        Weapon = weapon;
    }

    public Name Name { get; }
    public Race Race { get; }
    public Weapon Weapon { get; set; }
    public Region Region { get; private set; } = Region.Shire;

    public static Character Create(Name name, Race race, Weapon weapon)
    {
        if (weapon is null) {
            throw new ArgumentException("Character must have a weapon.");
        }

        return new Character(name, race, weapon);
    }

    public void ChangeRegion(Region region)
    {
        if (Region == Region.Mordor && region != Region.Mordor) {
            throw new InvalidOperationException($"Cannot move {Name} from Mordor to {region}. Reason: There is no coming back from Mordor.");
        }
        Region = region;
    }
}