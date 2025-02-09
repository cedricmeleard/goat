using LanguageExt;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Ports;
using LordOfTheRings.Domain.Specifications;

namespace LordOfTheRings.Infrastructure.Repositories;

public sealed class MemberRepository : IMemberRepository
{
    private readonly List<Character> _members = [];

    public Either<CharacterNotFound, Character> GetMember(ISpecification<Character> specification)
        => _members.FirstOrDefault(specification.IsSatisfiedBy)
           ?? Either<CharacterNotFound, Character>.Left(new CharacterNotFound());

    public void AddMember(Character character)
    {
        ArgumentNullException.ThrowIfNull(character);
        if (_members.Contains(character)) {
            throw new InvalidOperationException("Character already exists.");
        }
        _members.Add(character);
    }

    public void RemoveMember(Character character) => _members.Remove(character);

    public Either<NoMemberFound, IEnumerable<Character>> GetMembers(ISpecification<Character>? specification = null)
    {
        var members = specification != null
            ? _members.Where(specification.IsSatisfiedBy)
            : new List<Character>(_members);

        return members.Any()
            ? Either<NoMemberFound, IEnumerable<Character>>.Right(members)
            : Either<NoMemberFound, IEnumerable<Character>>.Left(new NoMemberFound());
    }
}