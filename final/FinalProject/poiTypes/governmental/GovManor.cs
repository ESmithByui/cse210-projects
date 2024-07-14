using System;
using System.Runtime;

public class GovManor : GovernmentalPOI
{
    private List<Person> guards = new List<Person>();
    private Random random = new Random();

    public GovManor(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int guardCount = random.Next(tier + 1, tier * 2 + 1);

        while (guardCount > guards.Count)
        {
            guards.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Manor: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Guards:");
        foreach (Person person in guards)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}