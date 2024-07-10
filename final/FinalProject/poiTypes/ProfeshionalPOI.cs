using System;

public abstract class ProfeshionalPOI : POI
{
    public ProfeshionalPOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}