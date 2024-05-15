using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        string userChoice = "";

        Journal userJournal = new Journal();

        do
        {
            Console.WriteLine($"Please select one of the following options:\n1. Write\n2. Display\n3. Save\n4. Load\n5. Quit");
            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine().ToLower();

            if(userChoice == "1" || userChoice == "write")
            {
                userJournal.Write();
            }

            else if(userChoice == "2" || userChoice == "display")
            {
                userJournal.Display();
            }

            else if(userChoice == "3" || userChoice == "save")
            {
                userJournal.Save();
            }

            else if(userChoice == "4" || userChoice == "load")
            {
                userJournal.Load();
            }

            else if(userChoice != "5" || userChoice == "quit")
            {
                Console.WriteLine("Not a valid option.");
            }

        }while (userChoice != "5");

        Console.WriteLine("Thank you for using the Journal Program!");
    }
}