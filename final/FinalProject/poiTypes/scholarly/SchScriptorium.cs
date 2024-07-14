using System;
using System.Runtime;

public class SchScriptorium : ScholarlyPOI
{
    private List<Person> scribes = new List<Person>();
    private Random random = new Random();

    public SchScriptorium(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int scribeCount = random.Next(tier + 1, tier * 3 + 1);

        while (scribeCount > scribes.Count)
        {
            scribes.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Scriptorium: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Scribes:");
        foreach (Person person in scribes)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}