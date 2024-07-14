using System;
using System.Runtime;

public class RelTemple : ReligiousPOI
{
    private List<Person> clerics = new List<Person>();
    private List<Person> acolytes = new List<Person>();
    private Random random = new Random();

    public RelTemple(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int clericCount = random.Next(2, tier + 4);
        int acolyteCount = random.Next(1, clericCount);

        while (clericCount > clerics.Count)
        {
            clerics.Add(gen.GenRandomPerson());
        }
        while (acolyteCount > acolytes.Count)
        {
            acolytes.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Temple: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Clerics:");
        foreach (Person person in clerics)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Acolytes:");
        foreach (Person person in acolytes)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}