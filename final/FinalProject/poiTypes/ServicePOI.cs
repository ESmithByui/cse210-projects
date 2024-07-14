using System;

public abstract class ServicePOI : POI
{
    public ServicePOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}