using LordOfTheRings.Domain;

namespace LordOfTheRings;

public class FellowshipOfTheRingService
{
    private readonly List<Character> _members = [];

    public void AddMember(Character character)
    {
        if (character == null) {
            throw new ArgumentNullException(nameof(character), "Character cannot be null.");
        }
        if (character.Weapon == null) {
            throw new ArgumentException("Character must have a weapon.");
        }

        bool exists = false;
        foreach (var member in _members) {
            if (member.Name == character.Name) {
                exists = true;
                break;
            }
        }

        if (exists) {
            throw new InvalidOperationException(
                "A character with the same name already exists in the fellowship.");
        }
        _members.Add(character);
    }

    public void UpdateCharacterWeapon(Name name, WeaponName newWeapon, Damage damage)
    {
        foreach (var character in _members) {
            if (character.Name == name) {
                character.Weapon = new Weapon(newWeapon, damage);
                break;
            }
        }
    }

    public void RemoveMember(Name name)
    {
        Character characterToRemove = null;
        foreach (var character in _members) {
            if (character.Name == name) {
                characterToRemove = character;
                break;
            }
        }

        if (characterToRemove == null) {
            throw new InvalidOperationException($"No character with the name '{name}' exists in the fellowship.");
        }
        _members.Remove(characterToRemove);
    }

    public void MoveMembersToRegion(List<Name> memberNames, Region region)
    {
        foreach (var name in memberNames) {
            foreach (var character in _members) {
                if (character.Name == name) {
                    character.ChangeRegion(region);
                    if (region != Region.Mordor) {
                        Console.WriteLine($"{character.Name} moved to {region}.");
                    } else {
                        Console.WriteLine($"{character.Name} moved to {region} 💀.");
                    }
                }
            }
        }
    }

    public void PrintMembersInRegion(Region region)
    {
        List<Character> charactersInRegion = new();
        foreach (var character in _members) {
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
        foreach (var member in _members) {
            result += $"{member.Name} ({member.Race}) with {member.Weapon.Name} in {member.Region}" + "\n";
        }

        return result;
    }
}