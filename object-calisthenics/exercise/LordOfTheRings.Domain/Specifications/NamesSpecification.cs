using System.Collections.Generic;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Specifications;

public class NamesSpecification : ISpecification<Character>
{
    private readonly List<Name> _names;
    private NamesSpecification(List<Name> names)
    {
        _names = names;
    }
    public bool IsSatisfiedBy(Character entity) => _names.Contains(entity.GetName());

    public static NamesSpecification ForNames(List<Name> names) => new(names);
}