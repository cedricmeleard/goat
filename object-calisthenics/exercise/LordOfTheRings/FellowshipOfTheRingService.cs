namespace LordOfTheRings
{
    public class FellowshipOfTheRingService
    {
        private readonly List<Character> _members = [];

        public void AddMember(Character character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character), "Character cannot be null.");
            }
            else if (string.IsNullOrWhiteSpace(character.Name))
            {
                throw new ArgumentException("Character must have a name.");
            }
            else if (string.IsNullOrWhiteSpace(character.Race))
            {
                throw new ArgumentException("Character must have a race.");
            }
            else if (character.Weapon == null)
            {
                throw new ArgumentException("Character must have a weapon.");
            }
            else if (string.IsNullOrWhiteSpace(character.Weapon.Name))
            {
                throw new ArgumentException("A weapon must have a name.");
            }
            else if (character.Weapon.Damage <= 0)
            {
                throw new ArgumentException("A weapon must have a damage level.");
            }
            else
            {
                bool exists = false;
                foreach (var member in _members)
                {
                    if (member.Name == character.Name)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    throw new InvalidOperationException(
                        "A character with the same name already exists in the fellowship.");
                }
                else
                {
                    _members.Add(character);
                }
            }
        }

        public void UpdateCharacterWeapon(string name, string newWeapon, int damage)
        {
            foreach (var character in _members)
            {
                if (character.Name == name)
                {
                    character.Weapon = new Weapon
                    {
                        Name = newWeapon,
                        Damage = damage
                    };
                    break;
                }
            }
        }

        public void RemoveMember(string name)
        {
            Character characterToRemove = null;
            foreach (var character in _members)
            {
                if (character.Name == name)
                {
                    characterToRemove = character;
                    break;
                }
            }

            if (characterToRemove == null)
            {
                throw new InvalidOperationException($"No character with the name '{name}' exists in the fellowship.");
            }
            else
            {
                _members.Remove(characterToRemove);
            }
        }

        public void MoveMembersToRegion(List<string> memberNames, string region)
        {
            foreach (var name in memberNames)
            {
                foreach (var character in _members)
                {
                    if (character.Name == name)
                    {
                        if (character.Region == "Mordor" && region != "Mordor")
                        {
                            throw new InvalidOperationException(
                                $"Cannot move {character.Name} from Mordor to {region}. Reason: There is no coming back from Mordor.");
                        }
                        else
                        {
                            character.Region = region;
                            if (region != "Mordor") Console.WriteLine($"{character.Name} moved to {region}.");
                            else Console.WriteLine($"{character.Name} moved to {region} 💀.");
                        }
                    }
                }
            }
        }

        public void PrintMembersInRegion(string region)
        {
            List<Character> charactersInRegion = new List<Character>();
            foreach (var character in _members)
            {
                if (character.Region == region)
                {
                    charactersInRegion.Add(character);
                }
            }

            if (charactersInRegion.Count > 0)
            {
                Console.WriteLine($"Members in {region}:");
                foreach (var character in charactersInRegion)
                {
                    Console.WriteLine($"{character.Name} ({character.Race}) with {character.Weapon.Name}");
                }
            }
            else if (charactersInRegion.Count == 0)
            {
                Console.WriteLine($"No members in {region}");
            }
        }

        public override string ToString()
        {
            var result = "Fellowship of the Ring Members:\n";
            foreach (var member in _members)
            {
                result += $"{member.Name} ({member.Race}) with {member.Weapon.Name} in {member.Region}" + "\n";
            }

            return result;
        }
    }
}