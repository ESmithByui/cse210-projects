using System;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        string play = "yes";

        int guessCount = 0;

        do{
            int magicNumber = rnd.Next(1,101);

            int guessNumber = 0;

            guessCount = 0;

            Console.WriteLine("Guess the magic number.");

            do
            {
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                guessNumber = int.Parse(guess);
                guessCount++;

                if (guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                
                else if (guessNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
            } while (guessNumber != magicNumber);

        Console.WriteLine($"The magic number is {magicNumber}! You got it in {guessCount} guesses!");

        Console.WriteLine("Would you like to play again? (yes/no)");
        play = Console.ReadLine();
        } while (play == "yes");
    }

}