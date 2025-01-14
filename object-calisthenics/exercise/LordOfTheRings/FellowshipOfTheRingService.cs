using System.Text;
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
        => Fellowship
            .GetAllMembers()
            .Where(character => NameSpecification
                .ForNames(memberNames)
                .IsSatisfiedBy(character))
            .Iter(character => character
                .ChangeRegion(region));

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
        => new StringBuilder()
            .AppendLine("Fellowship of the Ring Members:")
            .Append(string.Concat(
                Fellowship
                    .GetAllMembers()
                    .Select(member
                        => $"{member.GetName()} ({member.GetRace()}) with {member.GetWeaponName()} in {member.GetRegion()}\n")
                    .ToList()))
            .ToString();
}