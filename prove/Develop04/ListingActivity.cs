using System;
using System.Security.Cryptography.X509Certificates;

public class ListingActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> usedPrompts = new List<string>();

    private Random random = new Random();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }

    public override void RunActivity()
    {
        DisplayStartMessage();

        Console.Clear();
        string prompt = ChooseString(prompts, usedPrompts, random);
        Console.Write($"List as many responses you can to the following prompt.\n\n--- {prompt} ---\n\nYou may begin in: ");
        CountDown(10);
        Console.WriteLine(0);
        int timer = GetDuration();
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(timer);

        while (currentTime < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            currentTime = DateTime.Now;
        }



        DisplayEndMessage();
    }

}