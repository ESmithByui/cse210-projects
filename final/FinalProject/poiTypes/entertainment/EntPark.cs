using System;
using System.Runtime;

public class EntPark : EntertainmentPOI
{
    private List<Person> staff = new List<Person>();

    public EntPark(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Park: {GetName()}");
        returnString.Add($"Tier: {GetTier()}");
        return returnString;
    }
}