

// Example usage:
House myHouse = new House();
Room livingRoom = new Room { Name = "Living Room" };
SmartLight livingRoomLight = new SmartLight { Name = "Living Room Light" };
SmartTV livingRoomTV = new SmartTV { Name = "Living Room TV" };

livingRoom.Devices.Add(livingRoomLight);
livingRoom.Devices.Add(livingRoomTV);
myHouse.Rooms.Add(livingRoom);

Room bedroom = new Room { Name = "Bedroom" };
SmartTV bedroomTV = new SmartTV { Name = "Bedroom TV" };
bedroom.Devices.Add(bedroomTV);
myHouse.Rooms.Add(bedroom);

myHouse.GetRoomByName("Living Room").TurnOnAllLights();
myHouse.GetRoomByName("Bedroom").ReportAllDevicesStatus();
myHouse.GetRoomByName("Bedroom").TurnOnAllDevices();

myHouse.GetRoomByName("Bedroom").ReportAllDevicesStatus();
List<SmartDevice> devices = myHouse.GetRoomByName("Living Room").GetDevicesOn();
for(int i = 0;i<3;i++)
{
    Thread.Sleep(1000);

    foreach (SmartDevice device in devices)
    {
        device.UpdateTimeOn();
    }
}
myHouse.GetRoomByName("Living Room").ReportAllDevicesStatus();


// You can now perform operations on the house, rooms, and devices as per your requirements.
