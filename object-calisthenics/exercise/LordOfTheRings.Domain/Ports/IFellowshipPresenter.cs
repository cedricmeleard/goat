using System.Collections.Generic;
using System.Collections.ObjectModel;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Ports;

public interface IFellowshipPresenter
{
    string FormatFellowshipComposition(ReadOnlyCollection<Character> fellowshipMembers);
    string FormatMemberInRegion(IEnumerable<Character> charactersInRegion, Region region);
}