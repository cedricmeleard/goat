using LordOfTheRings.Domain.Entities;
using LordOfTheRings.Domain.Values;

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
            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Frodo"),
                Race.Hobbit,
                new Weapon(WeaponName.Parse("Sting"), Damage.Parse(30))
            ));

            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Sam"),
                Race.Hobbit,
                new Weapon(WeaponName.Parse("Dagger"), Damage.Parse(10))
            ));


            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Merry"),
                Race.Hobbit,
                new Weapon(WeaponName.Parse("Short Sword"), Damage.Parse(24))
            ));

            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Pippin"),
                Race.Hobbit,
                new Weapon(WeaponName.Parse("Bow"), Damage.Parse(8))
            ));

            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Aragorn"),
                Race.Human,
                new Weapon(WeaponName.Parse("Sword"), Damage.Parse(90))
            ));
            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Boromir"),
                Race.Human,
                new Weapon(WeaponName.Parse("Sword"), Damage.Parse(90))
            ));

            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Legolas"),
                Race.Elf,
                new Weapon(WeaponName.Parse("Bow"), Damage.Parse(100))
            ));

            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Gimli"),
                Race.Dwarf,
                new Weapon(WeaponName.Parse("Axe"), Damage.Parse(100))
            ));

            fellowship.Fellowship.AddMember(Character.Create(
                Name.Parse("Gandalf the 🐐"),
                Race.Wizard,
                new Weapon(WeaponName.Parse("Staff"), Damage.Parse(200))
            ));

            Console.WriteLine(fellowship.ToString());
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

        var group1 = new List<Name>
        {
            Name.Parse("Frodo"),
            Name.Parse("Sam")
        };
        var group2 = new List<Name>
        {
            Name.Parse("Merry"),
            Name.Parse("Pippin"),
            Name.Parse("Aragorn"),
            Name.Parse("Boromir")
        };
        var group3 = new List<Name>
        {
            Name.Parse("Legolas"),
            Name.Parse("Gimli"),
            Name.Parse("Gandalf the 🐐")
        };

        fellowship.MoveMembersToRegion(group1, Region.Rivendell);
        fellowship.UpdateCharacterWeapon(Name.Parse("Frodo"), WeaponName.Parse("Dard"), Damage.Parse(25));

        fellowship.Fellowship.RemoveMember(Name.Parse("Boromir"));

        try {
            fellowship.Fellowship.RemoveMember(Name.Parse("Saroumane")); //this should fail for "Saroumane"    
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }


        fellowship.MoveMembersToRegion(group2, Region.Moria);
        fellowship.MoveMembersToRegion(group3, Region.Lothlorien);

        fellowship.PrintMembersInRegion(Region.Rivendell);
        fellowship.PrintMembersInRegion(Region.Moria);
        fellowship.PrintMembersInRegion(Region.Lothlorien);
        fellowship.PrintMembersInRegion(Region.Mordor);
        fellowship.PrintMembersInRegion(Region.Shire);

        try {
            var group4 = new List<Name>
            {
                Name.Parse("Frodo"),
                Name.Parse("Sam")
            };
            fellowship.MoveMembersToRegion(group4, Region.Mordor);
            fellowship.MoveMembersToRegion(group4, Region.Shire); // This should fail for "Frodo"
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }

        // finaly Aragorn get reforged elendil's blade
        fellowship.UpdateCharacterWeapon(Name.Parse("Aragorn"), WeaponName.Parse("Anduril"), Damage.Parse(150));

        fellowship.PrintMembersInRegion(Region.Rivendell);
        fellowship.PrintMembersInRegion(Region.Moria);
        fellowship.PrintMembersInRegion(Region.Lothlorien);
        fellowship.PrintMembersInRegion(Region.Mordor);
        fellowship.PrintMembersInRegion(Region.Shire);

        try {
            fellowship.Fellowship.RemoveMember(Name.Parse("Frodo"));
            fellowship.Fellowship.RemoveMember(Name.Parse("Sam")); // This should throw an exception
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}