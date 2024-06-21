using System;
using System.Data;

public class SmartHeater : SmartDevice
{
    private int temp;

    public SmartHeater (string name) : base(name)
    {
        temp = 70;
    }

    public SmartHeater (string name, int temp) : base(name)
    {
        this.temp = temp;
    }

    public void AdjustTemp(int temp)
    {
        this.temp = temp;
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
            Console.WriteLine($"{TimeOn()} at {temp} degrees");
        }
    }
}