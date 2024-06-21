using System;
using System.Diagnostics;
using System.Linq.Expressions;

public class Room
{
    private string roomName;
    private List<SmartDevice> devices;

    public Room(string name, List<SmartDevice> devices)
    {
        roomName = name;
        this.devices = devices;
    }

    public void ReportAll()
    {
        Console.WriteLine($"{roomName}: All Devices\n~~~~~~~~~~~~~~~~");

        foreach(SmartDevice device in devices)
        {
            device.Report();
            Console.WriteLine("_____");
        }
    }

    public void ReportOn()
    {
        Console.WriteLine($"{roomName}: Active Devices\n~~~~~~~~~~~~~~~~");

        foreach(SmartDevice device in devices)
        {
            if (device.GetState())
            {
                device.Report();
                Console.WriteLine("_____");
            }
        }
    }

    public void ReportLongest()
    {
        Console.WriteLine($"{roomName}: Active Longest\n~~~~~~~~~~~~~~~~");
        if (devices.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            SmartDevice longest = devices[0];

            foreach(SmartDevice device in devices)
            {
                if(device.GetState() && (longest.GetTimeUpdated() > device.GetTimeUpdated()))
                {
                    longest = device;
                }
            }

            if (longest.GetState())
            {
                longest.Report();
            }
        }
    }



    public void ToggleAllLights(bool on)
    {
        foreach(SmartDevice device in devices)
        {
            if (device is SmartLight)
            {
                if (on)
                {
                    device.TurnDeviceOn();
                }
                else
                {
                    device.TurnDeviceOff();
                }
            }
        }
    }

    public void ToggleAllDevices(bool on)
    {
        foreach(SmartDevice device in devices)
        {
            if (on)
            {
                device.TurnDeviceOn();
            }
            else
            {
                device.TurnDeviceOff();
            }
        }
    }

    public void ToggleDevice(string deviceName)
    {
        bool notExist = true;
        foreach(SmartDevice device in devices)
        {
            if (deviceName == device.GetName())
            {
                if (device.GetState())
                {
                    device.TurnDeviceOff();
                }
                else
                {
                    device.TurnDeviceOn();
                }
                notExist = false;
            }
        }
        if (notExist)
        {
            Console.WriteLine("Device does not exist");
            Console.ReadLine();
        }
    }

    public string GetName()
    {
        return roomName;
    }

    public void ListDevices()
    {
        foreach(SmartDevice device in devices)
        {
            Console.WriteLine(device.GetName());
        }
    }

    public void LimitCheck(int time, string interval)
    {
        foreach(SmartDevice device in devices)
        {
            if(device.LimitHit(time, interval))
            {
                device.TurnDeviceOff();
            }
        }
    }

}