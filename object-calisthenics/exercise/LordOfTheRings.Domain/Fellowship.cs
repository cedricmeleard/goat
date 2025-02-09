using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LanguageExt;
using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Ports;
using LordOfTheRings.Domain.Specifications;
using LordOfTheRings.Domain.Values;

namespace LordOfTheRings.Domain;

public sealed class Fellowship(IFellowshipPresenter presenter, IMemberRepository memberRepository)
{
    private const string CharacterCannotBeNullMessage = "Character cannot be null.";
    private const string CharacterAlreadyExistsMessage = "A character with the same name already exists in the fellowship.";
    private const string CharacterDoesNotExistMessage = "No character with the name '{0}' exists in the fellowship.";

    public void AddMember(Character character)
    {
        if (character is null) {
            throw new ArgumentNullException(nameof(character), CharacterCannotBeNullMessage);
        }

        if (IsInFellowship(character)) {
            throw new InvalidOperationException(CharacterAlreadyExistsMessage);
        }

        memberRepository.AddMember(character);
    }

    public void RemoveMember(Name characterName)
    {
        var characterToRemove = FindMemberByName(characterName);
        if (characterToRemove is null) {
            throw new InvalidOperationException(string.Format(CharacterDoesNotExistMessage, characterName));
        }

        memberRepository.RemoveMember(characterToRemove);
    }

    private Character? FindMemberByName(Name name) => memberRepository.GetMember(NameSpecification.ForName(name));
    private bool IsInFellowship(Character character) => memberRepository.GetMember(NameSpecification.ForName(character.GetName())) != null;

    public void UpdateCharacterWeapon(Name name, WeaponName newWeapon, Damage damage)
        => FindMemberByName(name)?
            .ChangeWeapon(new Weapon(newWeapon, damage));

    public void MoveMembersToRegion(List<Name> memberNames, Region region)
        => memberRepository.GetMembers(NamesSpecification.ForNames(memberNames))
            .AsIterable()
            .Iter(character => character
                .ChangeRegion(region));

    public void PrintMembersInRegion(Region region)
    {
        var charactersInRegion = memberRepository.GetMembers(RegionSpecification.ForRegion(region))
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

    public override string ToString() => presenter?
        .FormatFellowshipComposition(new ReadOnlyCollection<Character>(memberRepository.GetMembers().ToList()));
}