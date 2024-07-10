using System;
using System.Runtime;

public class EntTheater : EntertainmentPOI
{
    private List<Person> staff = new List<Person>();
    private List<Person> vendors = new List<Person>();
    private Random random = new Random();

    public EntTheater(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int staffCount = random.Next(3, tier + 1);
        int vendorCount = random.Next(1, tier * 2 + 1);

        while (staffCount > staff.Count)
        {
            staff.Add(gen.GenRandomPerson());
        }

        while (vendorCount > vendors.Count)
        {
            vendors.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Theater: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner:\t{owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"\t\t{owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Staff:");
        foreach (Person person in staff)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Vendors:");
        foreach (Person person in vendors)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}