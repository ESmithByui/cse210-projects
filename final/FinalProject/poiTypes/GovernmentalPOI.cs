using System;

public abstract class GovernmentalPOI : POI
{
    public GovernmentalPOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}