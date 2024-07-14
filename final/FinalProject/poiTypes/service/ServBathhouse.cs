using System;
using System.Runtime;

public class ServBathhouse : ServicePOI
{
    private List<Person> stylists = new List<Person>();


    public ServBathhouse(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Bathhouse: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        return returnString;
    }
}