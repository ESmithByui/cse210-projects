using System;
using System.Runtime;

public class ServInn : ServicePOI
{
    private List<Person> staff = new List<Person>();
    private Random random = new Random();

    public ServInn(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int staffCount = random.Next(1, tier + 1);

        bool isFamily = false;

        if (random.Next(2) == 0)
        {
            isFamily = true;
        }

        while (staffCount > staff.Count)
        {
            if (isFamily)
            {
                staff.Add(gen.GenFamily(owner.GetLastName(), owner.GetRace()));
            }
            else
            {
                staff.Add(gen.GenRandomPerson());
            }
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Inn: {GetName()}");
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