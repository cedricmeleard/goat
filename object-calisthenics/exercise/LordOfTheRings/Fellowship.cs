using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings;

public sealed class Fellowship
{
    private const string CharacterCannotBeNullMessage = "Character cannot be null.";
    private const string CharacterAlreadyExistsMessage = "A character with the same name already exists in the fellowship.";
    private const string CharacterDoesNotExistMessage = "No character with the name '{0}' exists in the fellowship.";
    private readonly List<Character> _members = [];
    public void AddMember(Character character)
    {
        if (character == null) {
            throw new ArgumentNullException(nameof(character), CharacterCannotBeNullMessage);
        }

        if (IsInFellowship(character)) {
            throw new InvalidOperationException(CharacterAlreadyExistsMessage);
        }

        _members.Add(character);
    }
    public void RemoveMember(Name characterName)
    {
        var characterToRemove = FindMemberByName(characterName);
        if (characterToRemove is null) {
            throw new InvalidOperationException(string.Format(CharacterDoesNotExistMessage, characterName));
        }

        _members.Remove(characterToRemove);
    }
    public Character? GetMember(Name name) => FindMemberByName(name);
    public IReadOnlyCollection<Character> GetAllMembers() => new ReadOnlyCollection<Character>(_members);

    private Character? FindMemberByName(Name name) => _members.Find(character => character.GetName() == name);
    private bool IsInFellowship(Character character) => _members.Exists(m => m.GetName() == character.GetName());
}