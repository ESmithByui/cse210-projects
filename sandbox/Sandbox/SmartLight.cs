using System;
using System.Data;

public class SmartLight : SmartDevice
{
    public SmartLight (string name) : base(name)
    {

    }

    public override void TurnDeviceOn()
    {
        SetState(true);
    }

    public override void TurnDeviceOff()
    {
        SetState(false);
    }

    public override void Report()
    {
        string state = "Off";
        if (GetState())
        {
            state = "On";
        }
        
        Console.WriteLine($"{GetName()}: {state}");
        if (GetState())
        {
            Console.WriteLine(TimeOn());
        }
    }
}