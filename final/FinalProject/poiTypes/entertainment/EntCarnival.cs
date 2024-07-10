using System;
using System.Runtime;

public class EntCarnival : EntertainmentPOI
{
    private List<Person> staff = new List<Person>();

    public EntCarnival(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int staffCount = tier * 2;

        while (staffCount > staff.Count)
        {
            staff.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Carnival: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner:\t{owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"\t\t{owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Staff:");
        foreach (Person person in staff)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}