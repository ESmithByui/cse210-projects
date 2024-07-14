using System;
using System.Runtime;

public class SchAcademy : ScholarlyPOI
{
    private List<Person> staff = new List<Person>();
    private List<Person> professors = new List<Person>();
    private Random random = new Random();

    public SchAcademy(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int professorCount = random.Next(2, tier * 2 + 2);
        int staffCount = random.Next(professorCount, professorCount * 2);

        while (staffCount > staff.Count)
        {
            staff.Add(gen.GenRandomPerson());
        }
        while (professorCount > professors.Count)
        {
            professors.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Academy: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Professors:");
        foreach (Person person in professors)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Staff:");
        foreach (Person person in staff)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}