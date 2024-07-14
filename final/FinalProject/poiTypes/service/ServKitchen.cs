using System;
using System.Runtime;

public class ServKitchen : ServicePOI
{
    private List<Person> stylists = new List<Person>();


    public ServKitchen(string name, Person owner, int tier) : base(name, owner, tier)
    {

    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Kitchen: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner: {owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"         {owner.GetRace()}, {owner.GetGender()}");
        return returnString;
    }
}