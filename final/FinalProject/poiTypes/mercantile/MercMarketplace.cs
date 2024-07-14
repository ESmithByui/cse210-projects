using System;
using System.Runtime;

public class MercMarketplace : MercantilePOI
{
    private List<Person> vendors = new List<Person>();
    private Random random = new Random();

    public MercMarketplace(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int vendorCount = random.Next(tier, tier * 2 + 1);


        while (vendorCount > vendors.Count)
        {
            vendors.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Marketplace: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Vendors:");
        foreach (Person person in vendors)
        {
            returnString.Add($"    {person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"      {person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}