using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string userInput = Console.ReadLine();
        int gradePercent = int.Parse(userInput);

        string grade = "F";

        if (gradePercent >= 90)
        {
            grade = "A";
        }
        else if (gradePercent >= 80)
        {
            grade = "B";
        }
        else if (gradePercent >= 70)
        {
            grade = "C";
        }
        else if (gradePercent >= 60)
        {
            grade = "D";
        }

        int lastDigit = gradePercent % 10;

        string gradeMod = "";

        if (lastDigit >= 7 && (grade != "A" && grade != "F"))
        {
            gradeMod = "+";
        }
        else if (lastDigit <= 3 && grade != "F" && !(gradePercent >= 100))
        {
            gradeMod = "-";
        }

        string textMod = "a";
        if (grade == "A" || grade == "F")
        {
            textMod = "an";
        }

        Console.WriteLine($"You got {textMod} {grade}{gradeMod}.");

        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("You may not have passed this year, but you shouldn't stop trying.");
        }
    
    }
}