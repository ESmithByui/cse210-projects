using System;

public abstract class ScholarlyPOI : POI
{
    public ScholarlyPOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}