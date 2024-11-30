using LordOfTheRings.Domain;

namespace LordOfTheRings;

public class FellowshipOfTheRingService
{
    public Fellowship Fellowship { get; } = new();

    public void UpdateCharacterWeapon(Name name, WeaponName newWeapon, Damage damage)
    {
        var character = Fellowship.GetMember(name);
        if (character == null) {
            return;
        }

        character.Weapon = new Weapon(newWeapon, damage);
    }

    public void MoveMembersToRegion(List<Name> memberNames, Region region)
    {
        foreach (var name in memberNames) {
            var character = Fellowship.GetMember(name);
            if (character == null) {
                continue;
            }

            character.ChangeRegion(region);

            if (region != Region.Mordor) {
                Console.WriteLine($"{character.Name} moved to {region}.");
            } else {
                Console.WriteLine($"{character.Name} moved to {region} 💀.");
            }
        }
    }

    public void PrintMembersInRegion(Region region)
    {
        List<Character> charactersInRegion = new();
        foreach (var character in Fellowship.GetAllMembers()) {
            if (character.Region == region) {
                charactersInRegion.Add(character);
            }
        }

        if (charactersInRegion.Count > 0) {
            Console.WriteLine($"Members in {region}:");
            foreach (var character in charactersInRegion) {
                Console.WriteLine($"{character.Name} ({character.Race}) with {character.Weapon.Name}");
            }
        } else if (charactersInRegion.Count == 0) {
            Console.WriteLine($"No members in {region}");
        }
    }

    public override string ToString()
    {
        string result = "Fellowship of the Ring Members:\n";
        foreach (var member in Fellowship.GetAllMembers()) {
            result += $"{member.Name} ({member.Race}) with {member.Weapon.Name} in {member.Region}" + "\n";
        }

        return result;
    }
}