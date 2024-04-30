using System;

class Program
{
    static void Main(string[] args)
    {        
        DisplayWelcome();

        string name = PromptUserName();

        int number = PromptUserNumber();

        int numberSquared = SquareNumber(number);

        DisplayResult(name, numberSquared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    static int SquareNumber(int num)
    {
        int square = num * num;
        return square;
    }

    static void DisplayResult(string userName, int square)
    {
        Console.WriteLine($"{userName}, the square of your favorite number is {square}");
    }
    
}