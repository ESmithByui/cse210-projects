using System;
using System.Runtime;

public class CraftArsenal : CraftsmanPOI
{
    public CraftArsenal(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier, gen)
    {
  
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        List<Person> assistants = GetAssistants();
        returnString.Add($"Arsenal: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner:\t{owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"\t\t{owner.GetRace()}, {owner.GetGender()}");
        if (assistants.Count > 0)
        {
            returnString.Add("Assistants:");
            foreach (Person person in assistants)
            {
                returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
                returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
            }
        }
        return returnString;
    }
}