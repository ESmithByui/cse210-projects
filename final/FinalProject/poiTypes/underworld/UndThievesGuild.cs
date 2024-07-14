using System;
using System.Runtime;

public class UndThievesGuild : UnderworldPOI
{
    public UndThievesGuild(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Brothel: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        return returnString;
    }
}