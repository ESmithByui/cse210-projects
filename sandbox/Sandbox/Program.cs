using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        
        List<string> programs = new List<string>();

        programs.Add("Roulette");

        int i = 1;
        foreach (string program in programs)
        {
            Console.WriteLine($"{i}. {program}");
            i++;
        }

        Console.Write("Select program to run: ");
        int userSelection = int.Parse(Console.ReadLine());

        if (userSelection == 1)
        {
            Roulette();
        }
        
    }

    static void Roulette()
    {
        Console.Write("Enter how many players: ");
        int players = int.Parse(Console.ReadLine());

        Random rnd = new Random();

        while (players != 1)
        {
            Console.WriteLine($"There are {players} players left");
            int countDown = rnd.Next(1,7);
            do
            {

                Console.Write("Type anything to continue: ");
                Console.ReadLine();
                if (countDown == 1)
                {
                    Console.WriteLine("BANG! You're out of the game.");
                }
                else
                {
                    Console.WriteLine("Pass to the next player.");
                }

                countDown --;
                

            } while (countDown != 0);
            players --;
            
        }

        Console.WriteLine("Congratulations! You survived!");
    }
}