using System;
using System.Runtime;

public class SchLibrary : ScholarlyPOI
{
    private List<Person> librarians = new List<Person>();
    private Random random = new Random();

    public SchLibrary(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int librarianCount = random.Next(1, tier + 3);

        while (librarianCount > librarians.Count)
        {
            librarians.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Library: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Librarians:");
        foreach (Person person in librarians)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}