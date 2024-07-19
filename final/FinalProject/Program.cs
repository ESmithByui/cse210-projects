using System;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the D&D City Builder. Here you can make and export a city, or even an entire country.");
        Thread.Sleep(3000);
        Console.Write("Do you wish to build a:\n1. City\n2. Country\nChoose and option: ");
        string userInput = Console.ReadLine().ToLower();
        while (userInput != "1" && userInput != "2" && userInput != "city" && userInput != "country")
        {
            Console.Clear();
            Console.WriteLine($"{userInput} is not a valid option\n\n");
            Console.Write("Do you wish to build a:\n1. City\n2. Country\nChoose and option: ");
            userInput = Console.ReadLine().ToLower();
        }

        string goal = "country";
        if (userInput == "1" || userInput == "city")
        {
            goal = "city";
        }


        WorldManager world = new WorldManager(goal);
        world.Setup();

        Console.Clear();
        Console.WriteLine($"\n-----\n{goal} summary\n-----");
        world.DisplaySummary();

        Console.WriteLine("\nPress enter to continue...");
        Console.ReadKey();

        bool quit = false;
        bool saved = false;

        do
        {
            Console.Clear();
            Console.WriteLine($"Options:\n1. Save {goal}\n2. Display summary\n3. Display full infomation\n4. Quit");
            Console.Write("Choose an option: ");
            userInput = Console.ReadLine().ToLower();

            if (userInput == "1" || userInput == "save")
            {
                if (!saved)
                {
                    world.Export();
                    saved = true;
                }
                else
                {
                    Console.WriteLine($"\n{goal} already saved");
                }
            }
            else if (userInput == "2" || userInput == "display summary" || userInput == "summary")
            {
                world.DisplaySummary();
            }
            else if (userInput == "3" || userInput == "display full information" || userInput == "display full" || userInput == "full")
            {
                world.DisplayFull();
            }
            else if (userInput == "4" || userInput == "quit")
            {
                if (!saved)
                {    
                    Console.Write("\nAre you sure you want to exit? (Y/N) ");
                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "y")
                    {
                        quit = true;
                    }
                }
                else
                {
                    quit = true;
                }
            }
            else
            {
                Console.WriteLine("\nThat is not a valid option");
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();
        }while (!quit);

        Console.WriteLine("\nThank you for using the D&D City Builder Program!");

    }
}