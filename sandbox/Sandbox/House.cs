using System;

public class House
{
    private List<Room> rooms;

    public House(List<Room> rooms)
    {
        this.rooms = rooms;
    }

    private int SelectRoom()
    {
        Console.WriteLine("Select a room:");
        for(int i = 0; i < rooms.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {rooms[i].GetName()}");
        }
        Console.Write("Room No.: ");
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int userNumber))
        {
            return userNumber - 1;
        }
        else
        {
            return -1;
        }


    }

    public void RoomDevice()
    {
        int roomNum = SelectRoom();
        if (0 <= roomNum && roomNum <= rooms.Count())
        {
            rooms[roomNum].ListDevices();
            Console.Write($"Which device in {rooms[roomNum].GetName()} would you like to toggle? ");
            rooms[roomNum].ToggleDevice(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Room does not exist");
            Console.ReadLine();
        }
    }

    public void RoomAllDevices(bool on)
    {
        int roomNum = SelectRoom();
        if (0 <= roomNum && roomNum <= rooms.Count())
        {
            rooms[roomNum].ToggleAllDevices(on);
        }
        else
        {
            Console.WriteLine("Room does not exist");
            Console.ReadLine();
        }
    }

    public void RoomAllLights(bool on)
    {
        int roomNum = SelectRoom();
        if (0 <= roomNum && roomNum <= rooms.Count())
        {
            rooms[roomNum].ToggleAllLights(on);
        }
        else
        {
            Console.WriteLine("Room does not exist");
            Console.ReadLine();
        }
    }

    public void RoomReport(string type)
    {
        int roomNum = SelectRoom();
        Console.Clear();
        if (0 <= roomNum && roomNum <= rooms.Count())
        {
            if (type == "all")
            {
                rooms[roomNum].ReportAll();
            }
            else if (type == "on")
            {
                rooms[roomNum].ReportOn();
            }
            else if (type == "longest")
            {
                rooms[roomNum].ReportLongest();
            }
        }
        else
        {
            Console.WriteLine("Room does not exist");
        }
        Console.ReadLine();
    }

    public void AllDeviceToggle(bool on)
    {
        foreach(Room room in rooms)
        {
            room.ToggleAllDevices(on);
        }
    }

    public void AllLightToggle(bool on)
    {
        foreach(Room room in rooms)
        {
            room.ToggleAllLights(on);
        }
    }

    public void AllReport(string type)
    {
        Console.Clear();
        foreach(Room room in rooms)
        {
            if (type == "all")
            {
                room.ReportAll();
            }
            else if (type == "on")
            {
                room.ReportOn();
            }
        }
        Console.ReadLine();
    }

    public void RoomLimitChecks(int time, string interval)
    {
        foreach(Room room in rooms)
        {
            room.LimitCheck(time, interval);
        }
    }
}