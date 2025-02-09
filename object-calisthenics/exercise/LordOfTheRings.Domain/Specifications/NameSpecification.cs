using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Specifications;

public class NameSpecification : ISpecification<Character>
{
    private readonly Name _name;
    private NameSpecification(Name name)
    {
        _name = name;
    }
    public bool IsSatisfiedBy(Character entity) => _name == entity.GetName();
    public static NameSpecification ForName(Name name) => new(name);
}