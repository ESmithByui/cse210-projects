using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class ReflectionActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Think of a time you stood up for someone else.",
        "Think of a time you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> usedPrompts = new List<string>();

    private string[] questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> usedQuestions = new List<string>();

    private Random random = new Random();

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }

    public override void RunActivity()
    {
        DisplayStartMessage();

        Console.Clear();
        Console.WriteLine("Consider the following prompt:\n");
        string prompt = ChooseString(prompts, usedPrompts, random);
        Console.WriteLine($"--- {prompt} ---\n\nWhen you have somthing in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("Now ponder on each of the following questions as they relate to this experience.\n You may begin in: ");
        CountDown(5);

        int time = GetDuration();

        while(time > 0)
        {
            Console.Clear();
            Console.WriteLine($"--- {prompt} ---");
            Console.Write($"{ChooseString(questions, usedQuestions, random)} ");
            int count = 7;

            if (time < 12)
            {
                count = time;
            }
            SpinAnimation(count);
            time = time - count;
        }
        Console.WriteLine("\n");


        DisplayEndMessage();
    }

}