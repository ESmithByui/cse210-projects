using System;
using System.Runtime;

public class RelCemetary : ReligiousPOI
{
    public RelCemetary(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Cemetary: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Grave Keeper: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"                {owner.GetRace()}, {owner.GetGender()}");
        return returnString;
    }
}