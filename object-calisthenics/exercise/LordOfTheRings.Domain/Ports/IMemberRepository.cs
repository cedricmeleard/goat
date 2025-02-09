using System.Collections.Generic;
using LanguageExt;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Specifications;

namespace LordOfTheRings.Domain.Ports;

public interface IMemberRepository
{
    Either<NoMemberFound, IEnumerable<Character>> GetMembers(ISpecification<Character> specification = null);
    Either<CharacterNotFound, Character> GetMember(ISpecification<Character> specification);
    void AddMember(Character character);
    void RemoveMember(Character character);
}