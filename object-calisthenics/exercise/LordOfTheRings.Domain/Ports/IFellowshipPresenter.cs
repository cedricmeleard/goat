using System.Collections.ObjectModel;
using LordOfTheRings.Domain.Entities;

namespace LordOfTheRings.Domain.Ports;

public interface IFellowshipPresenter
{
    string FormatFellowshipComposition(ReadOnlyCollection<Character> fellowshipMembers);
}