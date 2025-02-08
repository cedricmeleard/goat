using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LanguageExt;
using LordOfTheRings.Domain.Ports;
using LordOfTheRings.Domain.Specifications;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain.Entities;

public sealed class Fellowship
{
    private const string CharacterCannotBeNullMessage = "Character cannot be null.";
    private const string CharacterAlreadyExistsMessage = "A character with the same name already exists in the fellowship.";
    private const string CharacterDoesNotExistMessage = "No character with the name '{0}' exists in the fellowship.";
    private readonly List<Character> _members = [];
    private readonly IFellowshipPresenter _presenter;

    private Fellowship(IFellowshipPresenter presenter)
    {
        _presenter = presenter;
    }

    public static Fellowship CreateInstance(IFellowshipPresenter presenter) => new(presenter);

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

    private Character? FindMemberByName(Name name) => _members.Find(character => character.GetName() == name);
    private bool IsInFellowship(Character character) => _members.Exists(m => m.GetName() == character.GetName());
    public void UpdateCharacterWeapon(Name name, WeaponName newWeapon, Damage damage)
        => FindMemberByName(name)?
            .ChangeWeapon(new Weapon(newWeapon, damage));
    public void MoveMembersToRegion(List<Name> memberNames, Region region)
        => _members
            .Where(character => NameSpecification
                .ForNames(memberNames)
                .IsSatisfiedBy(character))
            .AsIterable()
            .Iter(character => character
                .ChangeRegion(region));

    public void PrintMembersInRegion(Region region)
    {
        var charactersInRegion = _members
            .Where(character => RegionSpecification
                .ForRegion(region)
                .IsSatisfiedBy(character))
            .ToList();

        if (charactersInRegion.Count == 0) {
            Console.WriteLine($"No members in {region}");
            return;
        }

        Console.WriteLine($"Members in {region}:");
        foreach (var character in charactersInRegion) {
            Console.WriteLine($"{character.GetName()} ({character.GetRace()}) with {character.GetWeaponName()}");
        }
    }

    public override string ToString() => _presenter?
        .FormatFellowshipComposition(new ReadOnlyCollection<Character>(_members));
}