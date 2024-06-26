using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Goal Tracker");
        
        
        GoalManager manager = new GoalManager("goals.txt", "user.txt");

        string[] menu = new string[]{
            "1. Display User",
            "2. Display Current Goals",
            "3. Mark Goal Completed",
            "4. Display Goal Board",
            "5. Switch Goals",
            "6. Add New Goal",
            "7. Exit"
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
                    Console.Clear();
                    manager.DisplayUser();
                    break;

                case "2":
                    Console.Clear();
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.MarkCompletion();
                    break;

                case "4":
                    Console.Clear();
                    manager.DisplayGoalBoard();
                    break;

                case "5":
                    manager.SwitchGoals();
                    break;

                case "6":
                    manager.AddNewGoal();
                    break;

                case "7":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again");
                    Console.ReadLine();
                    break;
            }

            manager.RefillGoals();
            if (!quit)
            {
                Console.Write("Press enter to return to menu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Thank you for using our program!");
            }
            

        }while (!quit);

        
    }
}