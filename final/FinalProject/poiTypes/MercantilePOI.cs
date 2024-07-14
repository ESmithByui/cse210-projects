using System;

public abstract class MercantilePOI : POI
{
    public MercantilePOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}