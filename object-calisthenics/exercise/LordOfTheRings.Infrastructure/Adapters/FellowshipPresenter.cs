using System.Collections.ObjectModel;
using System.Text;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Ports;

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
}

public static class CharacterFellowshipExtension
{
    public static string DisplayMember(this Character member)
        => $"{member.GetName()} ({member.GetRace()}) with {member.GetWeaponName()} in {member.GetRegion()}\n";
}