using System.Collections.Generic;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Specifications;

namespace LordOfTheRings.Domain.Ports;

public interface IMemberRepository
{
    IEnumerable<Character> GetMembers(ISpecification<Character> specification = null);
    Character? GetMember(ISpecification<Character> specification);
    void AddMember(Character character);
    void RemoveMember(Character character);
}