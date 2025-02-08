using System.Collections.Generic;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Specifications;

public class NameSpecification : ISpecification<Character>
{
    private readonly List<Name> _names;
    private NameSpecification(List<Name> names)
    {
        _names = names;
    }
    public bool IsSatisfiedBy(Character entity) => _names.Contains(entity.GetName());

    public static NameSpecification ForNames(List<Name> names) => new(names);
}