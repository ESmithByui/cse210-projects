using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        string input = "0";
        int inputNumber = 0;
        
        do
        {
            Console.Write("Enter number: ");
            input = Console.ReadLine();
            
            if (input != "0")
            {
                inputNumber = int.Parse(input);
                numbers.Add(inputNumber);
            }
        } while (input != "0");

        int sum = numbers.Sum();
        var avr = numbers.Average();
        int max = numbers.Max();
        int minPositive = numbers.Where(x => x > 0).DefaultIfEmpty().Min();

        Console.WriteLine($"The sum is: {sum}\nThe average is: {avr}\nThe largest number is: {max}");
        if (minPositive != default(int))
        {
            Console.WriteLine($"The smallest positive number is: {minPositive}");
        }
        else
        {
            Console.WriteLine("There were no positive numbers.");
        }

        var numbersOrdered = numbers.OrderBy(x => x).ToList();

        Console.WriteLine("The sorted list is:");

        foreach (int number in numbersOrdered)
        {
            Console.WriteLine(number);
        }


        

        // sum
        // average
        //maximum
        //smallest positive
        //sorted list
    }
}