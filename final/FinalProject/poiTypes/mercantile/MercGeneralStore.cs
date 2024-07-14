using System;
using System.Runtime;

public class MercGeneralStore : MercantilePOI
{
    private List<Person> staff = new List<Person>();
    private Random random = new Random();

    public MercGeneralStore(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int staffCount = random.Next(1, tier +1);


        while (staffCount > staff.Count)
        {
            staff.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"General Store: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Staff:");
        foreach (Person person in staff)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}