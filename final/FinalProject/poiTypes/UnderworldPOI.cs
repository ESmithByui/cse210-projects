using System;

public abstract class UnderworldPOI : POI
{
    public UnderworldPOI(string name, Person owner, int tier) : base(name, owner, tier)
    {}

    public override abstract List<string> DisplayPOI();
}