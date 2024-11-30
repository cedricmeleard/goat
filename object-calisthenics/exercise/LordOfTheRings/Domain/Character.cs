namespace LordOfTheRings.Domain;

public sealed class Character(Name name, Race race, Weapon? weapon)
{
    public Name Name { get; } = name;
    public Race Race { get; } = race;
    public Weapon? Weapon { get; set; } = weapon;
    public Region Region { get; private set; } = Region.Shire;

    public void ChangeRegion(Region region)
    {
        if (Region == Region.Mordor && region != Region.Mordor) {
            throw new InvalidOperationException($"Cannot move {Name} from Mordor to {region}. Reason: There is no coming back from Mordor.");
        }
        Region = region;
    }
}