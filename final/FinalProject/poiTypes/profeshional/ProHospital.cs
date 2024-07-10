using System;
using System.Runtime;

public class ProHospital : ProfeshionalPOI
{
    private List<Person> doctors = new List<Person>();
    private List<Person> nurses = new List<Person>();
    private Random random = new Random();

    public ProHospital(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int doctorCount = random.Next(tier +1);

        int nurseCount = random.Next(doctorCount + 1, doctorCount * 2 + 3);


        while (doctorCount > doctors.Count)
        {
            doctors.Add(gen.GenRandomPerson());
        }

        while (nurseCount > nurses.Count)
        {
            nurses.Add(gen.GenRandomPerson());
        }
    }

    public override List<string> DisplayPOI()
    {
        List<string> returnString = new List<string>();
        Person owner = GetOwner();
        returnString.Add($"Hospital: {GetName()}");
        returnString.Add($"Tier {GetTier()}");
        returnString.Add($"Owner:\t{owner.GetFirstName()} {owner.GetLastName()}");
        returnString.Add($"\t\t{owner.GetRace()}, {owner.GetGender()}");
        returnString.Add("Doctors:");
        foreach (Person person in doctors)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        returnString.Add("Nurses:");
        foreach (Person person in nurses)
        {
            returnString.Add($"\t{person.GetFirstName()} {person.GetLastName()}");
            returnString.Add($"\t\t{person.GetRace()}, {person.GetGender()}");
        }
        return returnString;
    }
}