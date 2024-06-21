using System;
using System.Data;

public class SmartTV : SmartDevice
{
    private string channel;

    public SmartTV (string name) : base(name)
    {
        channel = "Roku";
    }

    public SmartTV (string name, string channel) : base(name)
    {
        this.channel = channel;
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
            Console.WriteLine($"{TimeOn()} on Channel: {channel}");
        }
    }
}