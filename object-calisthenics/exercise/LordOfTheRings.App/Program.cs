namespace LordOfTheRings.App;

public static class Program
{
    public static void Main(string[] args)
    {
        Run();
    }

    public static void Run()
    {
        var fellowship = new FellowshipOfTheRingService();

        try {
            fellowship.AddMember(new Character
            {
                Name = "Frodo",
                Race = "Hobbit",
                Weapon = new Weapon
                {
                    Name = "Sting",
                    Damage = 30
                }
            });

            fellowship.AddMember(new Character
            {
                Name = "Sam",
                Race = "Hobbit",
                Weapon = new Weapon
                {
                    Name = "Dagger",
                    Damage = 10
                }
            });


            fellowship.AddMember(new Character
            {
                Name = "Merry",
                Race = "Hobbit",
                Weapon = new Weapon
                {
                    Name = "Short Sword",
                    Damage = 24
                }
            });

            fellowship.AddMember(new Character
            {
                Name = "Pippin",
                Race = "Hobbit",
                Weapon = new Weapon
                {
                    Name = "Bow",
                    Damage = 8
                }
            });

            fellowship.AddMember(new Character
            {
                Name = "Aragorn",
                Race = "Human",
                Weapon = new Weapon
                {
                    Name = "Sword",
                    Damage = 90
                }
            });
            fellowship.AddMember(new Character
            {
                Name = "Boromir",
                Race = "Human",
                Weapon = new Weapon
                {
                    Name = "Sword",
                    Damage = 90
                }
            });

            fellowship.AddMember(new Character
            {
                Name = "Legolas",
                Race = "Elf",
                Weapon = new Weapon
                {
                    Name = "Bow",
                    Damage = 100
                }
            });

            fellowship.AddMember(new Character
            {
                Name = "Gimli",
                Race = "Dwarf",
                Weapon = new Weapon
                {
                    Name = "Axe",
                    Damage = 100
                }
            });

            fellowship.AddMember(new Character
            {
                Name = "Gandalf the 🐐",
                Race = "Wizard",
                Weapon = new Weapon
                {
                    Name = "Staff",
                    Damage = 200
                }
            });

            Console.WriteLine(fellowship.ToString());
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

        var group1 = new List<string>
        {
            "Frodo",
            "Sam"
        };
        var group2 = new List<string>
        {
            "Merry",
            "Pippin",
            "Aragorn",
            "Boromir"
        };
        var group3 = new List<string>
        {
            "Legolas",
            "Gimli",
            "Gandalf the 🐐"
        };

        fellowship.MoveMembersToRegion(group1, "Rivendell");
        fellowship.UpdateCharacterWeapon("Frodo", "Dard", 25);

        fellowship.RemoveMember("Boromir");

        try {
            fellowship.RemoveMember("Saroumane"); //this should fail for "Saroumane"    
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }


        fellowship.MoveMembersToRegion(group2, "Moria");
        fellowship.MoveMembersToRegion(group3, "Lothlorien");

        fellowship.PrintMembersInRegion("Rivendell");
        fellowship.PrintMembersInRegion("Moria");
        fellowship.PrintMembersInRegion("Lothlorien");
        fellowship.PrintMembersInRegion("Mordor");
        fellowship.PrintMembersInRegion("Shire");

        try {
            var group4 = new List<string>
            {
                "Frodo",
                "Sam"
            };
            fellowship.MoveMembersToRegion(group4, "Mordor");
            fellowship.MoveMembersToRegion(group4, "Shire"); // This should fail for "Frodo"
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

        // finaly Aragorn get reforged elendil's blade
        fellowship.UpdateCharacterWeapon("Aragorn", "Anduril", 150);

        fellowship.PrintMembersInRegion("Rivendell");
        fellowship.PrintMembersInRegion("Moria");
        fellowship.PrintMembersInRegion("Lothlorien");
        fellowship.PrintMembersInRegion("Mordor");
        fellowship.PrintMembersInRegion("Shire");

        try {
            fellowship.RemoveMember("Frodo");
            fellowship.RemoveMember("Sam"); // This should throw an exception
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}