using LordOfTheRings.Domain;

namespace LordOfTheRings;

public class Fellowship
{
    private readonly List<Character> _members = [];
    public void AddMember(Character character)
    {
        if (character == null) {
            throw new ArgumentNullException(nameof(character), "Character cannot be null.");
        }
        if (character.Weapon == null) {
            throw new ArgumentException("Character must have a weapon.");
        }

        bool exists = false;
        foreach (var member in _members) {
            if (member.Name == character.Name) {
                exists = true;
                break;
            }
        }

        if (exists) {
            throw new InvalidOperationException(
                "A character with the same name already exists in the fellowship.");
        }
        _members.Add(character);
    }
    public void RemoveMember(Name name)
    {
        Character characterToRemove = null;
        foreach (var character in _members) {
            if (character.Name == name) {
                characterToRemove = character;
                break;
            }
        }

        if (characterToRemove == null) {
            throw new InvalidOperationException($"No character with the name '{name}' exists in the fellowship.");
        }
        _members.Remove(characterToRemove);
    }

    public Character? GetMember(Name name) => _members.FirstOrDefault(character => character.Name == name);
    public IEnumerable<Character> GetAllMembers() => _members.ToList();
}