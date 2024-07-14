using System;

public abstract class TradesmanPOI : POI
{
    private List<Person> assistants = new List<Person>();
    private Random random = new Random();
    public TradesmanPOI(string name, Person owner, int tier, PersonGenerator gen) : base(name, owner, tier)
    {
        int assistantCount = 0;
        if (tier == 3)
        {
            assistantCount = random.Next(2);
        }
        else if (tier > 3)
        {
            assistantCount = random.Next(1,4);
        }

        while (assistantCount > assistants.Count)
        {
            assistants.Add(gen.GenRandomPerson());
        }
    }

    public List<Person> GetAssistants()
    {
        return assistants;
    }
    public override abstract List<string> DisplayPOI();
}