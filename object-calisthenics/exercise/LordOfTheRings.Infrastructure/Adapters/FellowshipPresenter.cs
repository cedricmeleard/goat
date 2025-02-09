using System.Collections.ObjectModel;
using System.Text;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Ports;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Infrastructure.Adapters;

public class FellowshipPresenter : IFellowshipPresenter
{
    public string FormatFellowshipComposition(ReadOnlyCollection<Character> fellowshipMembers)
        => new StringBuilder()
            .AppendLine("Fellowship of the Ring Members:")
            .Append(string.Concat(
                fellowshipMembers
                    .Select(member => member.DisplayMember())
                    .ToList()))
            .ToString();
    public string FormatMemberInRegion(IEnumerable<Character> charactersInRegion, Region region)
    {
        var sb = new StringBuilder($"Members in {region}:");
        foreach (var character in charactersInRegion) {
            sb.AppendLine().Append($"{character.GetName()} ({character.GetRace()}) with {character.GetWeaponName()}");
        }
        return sb.ToString();
    }
}

public static class CharacterFellowshipExtension
{
    public static string DisplayMember(this Character member)
        => $"{member.GetName()} ({member.GetRace()}) with {member.GetWeaponName()} in {member.GetRegion()}\n";
}