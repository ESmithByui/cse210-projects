using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        
        
        House myHouse = new House( new List<Room>
        {
            new Room("Front Room", new List<SmartDevice>{
                new SmartLight("FR: Light 1"),
                new SmartLight("FR: Light 2"),
                new SmartTV("FR: TV"),
                new SmartHeater("FR: Heater")
            }),
            new Room("Living Room", new List<SmartDevice>{
                new SmartLight("LR: Light 1"),
                new SmartTV("LR: TV"),
                new SmartHeater("LR: Heater")
            }),
            new Room("Kitchen", new List<SmartDevice>{
                new SmartLight("K: Light 1"),
                new SmartLight("K: Light 2")
            }),
            new Room("Bedroom", new List<SmartDevice>{
                new SmartLight("B: Light 1"),
                new SmartLight("B: Light 2"),
                new SmartTV("B: TV"),
                new SmartHeater("B: Heater")
            })
        });

        string[] menu = new string[]{
            "1. Turn Device ON/OFF",
            "2. Turn All Devices ON in a Room",
            "3. Turn All Devices OFF in a Room",
            "4. Turn All Lights ON in a Room",
            "5. Turn All Lights OFF in a Room",
            "6. Device Report in a Room",
            "7. Active Device Report in a Room",
            "8. Longest Active Decive in a Room",
            "9. Turn ALL Devices ON",
            "10. Turn ALL Devices OFF",
            "11. Turn ALL Lights ON",
            "12. Turn ALL Lights OFF",
            "13. Report ALL Devices",
            "14. Report ALL Active Devices",
            "15. Quit"
        };

        bool quit = false;

        do
        {
            Console.Clear();
            foreach(string item in menu)
            {
                Console.WriteLine(item);
            }
            Console.Write("Choose an option: ");

            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "1":
                    myHouse.RoomDevice();
                    break;

                case "2":
                    myHouse.RoomAllDevices(true);
                    break;

                case "3":
                    myHouse.RoomAllDevices(false);
                    break;

                case "4":
                    myHouse.RoomAllLights(true);
                    break;

                case "5":
                    myHouse.RoomAllLights(false);
                    break;

                case "6":
                    myHouse.RoomReport("all");
                    break;

                case "7":
                    myHouse.RoomReport("on");
                    break;

                case "8":
                    myHouse.RoomReport("longest");
                    break;

                case "9":
                    myHouse.AllDeviceToggle(true);
                    break;

                case "10":
                    myHouse.AllDeviceToggle(false);
                    break;

                case "11":
                    myHouse.AllLightToggle(true);
                    break;

                case "12":
                    myHouse.AllLightToggle(false);
                    break;

                case "13":
                    myHouse.AllReport("all");
                    break;

                case "14":
                    myHouse.AllReport("on");
                    break;

                case "15":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again");
                    Console.ReadLine();
                    break;
            }

            myHouse.RoomLimitChecks(5, "minute");

        }while (!quit);

        
    }
}