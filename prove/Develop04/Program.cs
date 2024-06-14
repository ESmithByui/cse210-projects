using System;
using System.Runtime.InteropServices;


class Program
{
    static void Main(string[] args)
    {
        string timeInitialized = DateTime.Now.ToString("MM-dd-yyyy_H-mm-ss");
        timeInitialized = $"{timeInitialized}.txt";
        CreateLog logger = new CreateLog(timeInitialized);

        Activity[] activities = new Activity[]
        {
            new BreathingActivity(logger),
            new ReflectionActivity(logger),
            new ListingActivity(logger)
        };

        string[] menuOptions = new string[]
        {
            "  1. Start Breathing Activity",
            "  2. Start Reflection Activity",
            "  3. Start Listing Activity",
            "  4. Quit"
        };

        bool chosenQuit = false;

        

        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            foreach(string option in menuOptions)
            {
                Console.WriteLine(option);
            }
            Console.Write("Select a choice from the menu: ");
            string userInput = Console.ReadLine().ToLower();

            if (menuOptions[0].ToLower().Contains(userInput))
            {
                activities[0].RunActivity();
            }
            else if (menuOptions[1].ToLower().Contains(userInput))
            {
                activities[1].RunActivity();
            }
            else if (menuOptions[2].ToLower().Contains(userInput))
            {
                activities[2].RunActivity();
            }
            else if (menuOptions[3].ToLower().Contains(userInput))
            {
                chosenQuit = true;
            }
            
        }while (!chosenQuit);

        logger.WriteLog("Program successfully exited.");
    }
}