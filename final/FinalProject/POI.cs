using System;

public abstract class POI
{
    private string name;
    private Person owner;
    private int tier;

    public POI(string name, Person owner, int tier)
    {
        this.name = name;
        this.owner = owner;
        this.tier = tier;
    }

    public string GetName()
    {
        return name;
    }

    public Person GetOwner()
    {
        return owner;
    }

    public int GetTier()
    {
        return tier;
    }

    public abstract List<string> DisplayPOI();
}