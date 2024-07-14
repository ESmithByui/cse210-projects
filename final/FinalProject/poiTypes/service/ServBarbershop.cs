using System;
using System.Runtime;

public class ServBarbershop : ServicePOI
{
    private List<Person> stylists = new List<Person>();
    private Random random = new Random();

    public ServBarbershop(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int stylistCount = random.Next(2, 7);


        while (stylistCount > stylists.Count)
        {
            stylists.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Barbershop: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Stylists:");
        foreach (Person person in stylists)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}