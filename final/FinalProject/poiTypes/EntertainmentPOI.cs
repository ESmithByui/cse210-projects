using System;

public abstract class EntertainmentPOI : POI
{
    public EntertainmentPOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}