using System;
using System.Runtime;

public class RelShrine : ReligiousPOI
{
    public RelShrine(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Shrine: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        return returnString;
    }
}