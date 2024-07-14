using System;
using System.Runtime;

public class GovLeadersHouse : GovernmentalPOI
{
    private List<Person> guards = new List<Person>();
    private Random random = new Random();

    public GovLeadersHouse(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Leader's House: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        return returnString;
    }
}