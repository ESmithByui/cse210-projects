using System;
using System.Runtime.InteropServices;


class Program
{
    static void Main(string[] args)
    {

        Activity[] activities = new Activity[]
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
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
    }
}