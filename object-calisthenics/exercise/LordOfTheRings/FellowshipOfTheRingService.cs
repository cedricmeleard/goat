using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Specifications;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings;

public class FellowshipOfTheRingService
{
    public Fellowship Fellowship { get; } = new();

    public void UpdateCharacterWeapon(Name name, WeaponName newWeapon, Damage damage)
        => Fellowship
            .GetMember(name)?
            .ChangeWeapon(new Weapon(newWeapon, damage));

    public void MoveMembersToRegion(List<Name> memberNames, Region region)
    {
        foreach (var name in memberNames) {
            var character = Fellowship.GetMember(name);
            if (character == null) {
                continue;
            }

            character.ChangeRegion(region);

            // let's see if that can be moved to domain events
            if (region != Region.Mordor) {
                Console.WriteLine($"{character.GetName()} moved to {region}.");
            } else {
                Console.WriteLine($"{character.GetName()} moved to {region} 💀.");
            }
        }
    }

    public void PrintMembersInRegion(Region region)
    {
        var charactersInRegion = Fellowship
            .GetAllMembers()
            .Where(character => RegionSpecification
                .ForRegion(region)
                .IsSatisfiedBy(character))
            .ToList();

        if (charactersInRegion.Count == 0) {
            Console.WriteLine($"No members in {region}");
            return;
        }

        Console.WriteLine($"Members in {region}:");
        foreach (var character in charactersInRegion) {
            Console.WriteLine($"{character.GetName()} ({character.GetRace()}) with {character.GetWeaponName()}");
        }
    }

    public override string ToString()
    {
        string result = "Fellowship of the Ring Members:\n";

        foreach (var member in Fellowship.GetAllMembers()) {
            result += $"{member.GetName()} ({member.GetRace()}) with {member.GetWeaponName()} in {member.GetRegion()}" + "\n";
        }

        return result;
    }
}