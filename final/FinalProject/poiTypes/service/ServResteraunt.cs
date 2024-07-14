using System;
using System.Runtime;

public class ServResteraunt : ServicePOI
{
    private List<Person> chefs = new List<Person>();
    private List<Person> waiters = new List<Person>();
    private Random random = new Random();

    public ServResteraunt(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int chefCount = random.Next(4, tier + 1);
        int waiterCount = random.Next(4, tier * 2 + 1);

        while (chefCount > chefs.Count)
        {
            chefs.Add(gen.GenRandomPerson());
        }
        while (waiterCount > waiters.Count)
        {
            if (random.Next(10) == 0)
            {
                waiters.Add(gen.GenFamily(owner.GetLastName(), owner.GetRace()));
            }
            else
            {
                waiters.Add(gen.GenRandomPerson());
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
        returnString.Add("Chefs:");
        foreach (Person person in chefs)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Waiters:");
        foreach (Person person in waiters)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}