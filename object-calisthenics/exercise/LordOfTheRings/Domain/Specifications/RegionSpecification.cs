using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Specifications;

public class RegionSpecification : ISpecification<Character>
{
    private readonly Region _region;
    private RegionSpecification(Region region)
    {
        _region = region;
    }

    public static RegionSpecification ForRegion(Region region) => new(region);

    public bool IsSatisfiedBy(Character character) => character.IsFromRegion(_region);
}