using System;
using System.Runtime;

public class SchAlchemist : ScholarlyPOI
{
    private List<Person> assistants = new List<Person>();
    private Random random = new Random();

    public SchAlchemist(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int assistantCount = random.Next(2, tier + 2);

        while (assistantCount > assistants.Count)
        {
            assistants.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Alchemist: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Assistants:");
        foreach (Person person in assistants)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}