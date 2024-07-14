using System;

public abstract class ReligiousPOI : POI
{
    public ReligiousPOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}