using System;
using System.Collections.Generic;

abstract class SmartDevice
{
    public string Name { get; set; }
    public bool IsOn { get; protected set; }
    public TimeSpan TimeOn { get; protected set; }

    public void TurnOn()
    {
        IsOn = true;
    }

    public void TurnOff()
    {
        IsOn = false;
    }

    public void UpdateTimeOn()
    {
        if (IsOn)
            TimeOn = TimeOn.Add(TimeSpan.FromMinutes(1)); // Assuming the time is updated every minute
    }
}

class SmartLight : SmartDevice { }

class SmartHeater : SmartDevice { }

class SmartTV : SmartDevice { }

class Room
{
    public List<SmartDevice> Devices { get; } = new List<SmartDevice>();
    public string Name { get; set; }

    public void TurnOnAllLights()
    {
        foreach (var device in Devices)
        {
            if (device is SmartLight light)
                light.TurnOn();
        }
    }

    public void TurnOffAllLights()
    {
        foreach (var device in Devices)
        {
            if (device is SmartLight light)
                light.TurnOff();
        }
    }

    public void TurnOnDevice(string deviceName)
    {
        var device = Devices.Find(d => d.Name == deviceName);
        device?.TurnOn();
    }

    public void TurnOffDevice(string deviceName)
    {
        var device = Devices.Find(d => d.Name == deviceName);
        device?.TurnOff();
    }

    public void TurnOnAllDevices()
    {
        foreach (var device in Devices)
        {
            device.TurnOn();
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var device in Devices)
        {
            device.TurnOff();
        }
    }

    public void ReportAllDevicesStatus()
    {
        foreach (var device in Devices)
        {
            Console.WriteLine($"{device.Name}: Is On - {device.IsOn}, Time On - {device.TimeOn}");
        }
    }

    public List<SmartDevice> GetDevicesOn()
    {
        return Devices.FindAll(device => device.IsOn);
    }

    public SmartDevice GetLongestRunningDevice()
    {
        var longestRunningDevice = Devices.OrderByDescending(device => device.TimeOn).FirstOrDefault();
        return longestRunningDevice;
    }
}

class House
{
    public List<Room> Rooms { get; } = new List<Room>();

    public Room GetRoomByName(string roomName)
    {
        return Rooms.Find(room => room.Name == roomName);
    }
}

class HouseSchedule
{
    public List<Event> Events { get; } = new List<Event>();

    public void AddEvent(Event ev)
    {
        Events.Add(ev);
    }

    public void ExecuteEvents()
    {
        foreach (var ev in Events)
        {
            ev.Execute();
        }
    }
}

class Event
{
    public SmartDevice Device { get; set; }
    public TimeSpan Delay { get; set; }
    public bool TurnOn { get; set; }

    public void Execute()
    {
        // Implement event execution based on the specified conditions
        // You can use Device, Delay, and TurnOn properties to control the event execution
    }
}