using System;
using System.Runtime;

public class EntMuseum : EntertainmentPOI
{
    private List<Person> guides = new List<Person>();
    private List<Person> dayGuards = new List<Person>();
    private List<Person> nightGuards = new List<Person>();
    private Random random = new Random();

    public EntMuseum(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int guideCount = random.Next(1, tier + 1);
        int dayGuardsCount = random.Next(1, tier + 2);
        int nightGuardsCount = random.Next(1, tier);

        while (guideCount > guides.Count)
        {
            guides.Add(gen.GenRandomPerson());
        }

        while (dayGuardsCount > dayGuards.Count)
        {
            dayGuards.Add(gen.GenRandomPerson());
        }

        while (nightGuardsCount > nightGuards.Count)
        {
            nightGuards.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Museum: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner:\t{owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"\t\t{owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Guides:");
        foreach (Person person in guides)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Day Guards:");
        foreach (Person person in dayGuards)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Night Guards:");
        foreach (Person person in nightGuards)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}