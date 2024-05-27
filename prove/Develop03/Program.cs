using System;
using System.Buffers;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Timers;

class Program
{
    static void Main(string[] args)
    {

        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");

        Library collection = new Library("testRepository.txt");

        string userInput = "";

        int wordHideAmount = 3;

        bool memoryType = true;

        string[] menu1 = new string[]
        {
            "1. SELECT scripture to memorize",
            "2. DISPLAY available scriptures",
            "3. LOAD scripture file",
            "4. SETTINGS",
            "5. QUIT"
        };

        string[] menu2 = new string[]
        {
            "1. NUMBER of words to hide",
            "2. MEMORIZE by reference or verse",
            "3. RETURN to menu"
        };

        do
        {
            Console.WriteLine("Choose one of the following:");
            foreach(string option in menu1)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            userInput = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (userInput == "2" || userInput == "display")
            {
                Console.Clear();
                Console.WriteLine("Scriptures Loaded:");
                collection.DisplayReferences();

                Console.WriteLine("Type in (1) or (select) to choose scripture or enter to return to menu:");
                userInput = Console.ReadLine().ToLower();

                if (userInput != "1" && userInput != "select")
                {
                    userInput = "2";
                    Console.WriteLine("Press enter to continue:");
                }
            }
            else if (userInput == "3" || userInput == "load")
            {
                Console.Write("Which file would you like to load: ");
                collection = new Library(Console.ReadLine());
                Console.WriteLine("File loaded, press enter to continue:");
            }
            else if (userInput == "4" || userInput == "settings")
            {
                Console.Clear();
                Console.WriteLine("Choose one of the following:");
                foreach(string option in menu2)
                {
                    Console.WriteLine(option);
                }
                Console.WriteLine();
                userInput = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (userInput == "1" || userInput == "number")
                {
                    Console.WriteLine($"The current number is {wordHideAmount}");
                    Console.Write("The new number is: ");
                    wordHideAmount = int.Parse(Console.ReadLine());

                    Console.WriteLine("Change made, press enter to continue:");
                }
                else if (userInput == "2" || userInput == "memorize")
                {
                    string memorize = "Reference";
                    if (memoryType == false)
                    {
                        memorize = "Verse";
                    }

                    Console.WriteLine($"The current memorization type is by {memorize}");
                    Console.Write("Type (reference) or (verse) to change setting: ");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "reference")
                    {
                        memoryType = true;
                        Console.WriteLine("Change made, press enter to continue:");
                    }
                    else if (userInput == "verse")
                    {
                        memoryType = false;
                        Console.WriteLine("Change made, press enter to continue:");
                    }
                    else
                    {
                        Console.WriteLine("No change made, press enter to continue:");
                    }


                    
                }
                else if (userInput != "3" && userInput != "return")
                {
                    Console.WriteLine("Valid option not recognized, press enter to continue:");
                }
                userInput = "4";
            }
            else if (userInput != "1" && userInput != "select" && userInput != "5" && userInput != "quit")
            {
                Console.WriteLine("Valid option not recognized, press enter to continue:");
            }
            
            if (userInput == "1" || userInput == "select")
            {
                Console.WriteLine("Type in the scripture you wish to memorize:");
                string scriptureReference = Console.ReadLine();
                if (int.TryParse(scriptureReference, out _))
                {
                    scriptureReference = collection.GetSpecificReference(int.Parse(scriptureReference) - 1);
                }
                collection.ChooseScripture(scriptureReference, memoryType, wordHideAmount);
                Console.WriteLine("Memorizaiton completed, press enter to continue:");
            }
            
            if (userInput == "5" || userInput == "quit")
            {
                Console.Write("Thank you, have a nice day!");
            }
            else
            {
                Console.ReadLine();
                Console.Clear();
            }
        }while (userInput != "quit" && userInput != "5");


    }
}