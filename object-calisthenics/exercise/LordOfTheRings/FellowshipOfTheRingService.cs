namespace LordOfTheRings
{
    public class FellowshipOfTheRingService
    {
        private List<Character> members = new List<Character>();

        public void AddMember(Character character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character), "Character cannot be null.");
            }
            else if (string.IsNullOrWhiteSpace(character.N))
            {
                throw new ArgumentException("Character must have a name.");
            }
            else if (string.IsNullOrWhiteSpace(character.R))
            {
                throw new ArgumentException("Character must have a race.");
            }
            else if (string.IsNullOrWhiteSpace(character.W))
            {
                throw new ArgumentException("Character must have a weapon.");
            }
            else
            {
                bool exists = false;
                foreach (var member in members)
                {
                    if (member.N == character.N)
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
                    members.Add(character);
                }
            }
        }

        public void UpdateCharacterWeapon(string name, string newWeapon)
        {
            foreach (var character in members)
            {
                if (character.N == name)
                {
                    character.W = newWeapon;
                    break;
                }
            }
        }

        public void RemoveMember(string name)
        {
            Character characterToRemove = null;
            foreach (var character in members)
            {
                if (character.N == name)
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
                members.Remove(characterToRemove);
            }
        }

        public void MoveMembersToRegion(List<string> memberNames, string region)
        {
            foreach (var name in memberNames)
            {
                foreach (var character in members)
                {
                    if (character.N == name)
                    {
                        if (character.C == "Mordor" && region != "Mordor")
                        {
                            throw new InvalidOperationException(
                                $"Cannot move {character.N} from Mordor to {region}. Reason: There is no coming back.");
                        }
                        else
                        {
                            character.C = region;
                            if (region != "Mordor") Console.WriteLine($"{character.N} moved to {region}.");
                            else Console.WriteLine($"{character.N} moved to {region} 💀.");
                        }
                    }
                }
            }
        }

        public void PrintMembersInRegion(string region)
        {
            List<Character> charactersInRegion = new List<Character>();
            foreach (var character in members)
            {
                if (character.C == region)
                {
                    charactersInRegion.Add(character);
                }
            }

            Console.WriteLine($"Members in {region}:");
            foreach (var character in charactersInRegion)
            {
                Console.WriteLine($"{character.N} ({character.R}) with {character.W}");
            }
        }

        public override string ToString()
        {
            var result = "Fellowship of the Ring Members:\n";
            foreach (var member in members)
            {
                result += member + "\n";
            }

            return result;
        }
    }
}