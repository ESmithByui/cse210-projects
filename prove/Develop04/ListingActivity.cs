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

    public ListingActivity(CreateLog log) : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", log)
    {

    }

    public override void RunActivity()
    {
        DisplayStartMessage();

        Console.Clear();
        string prompt = ChooseString(prompts, usedPrompts);
        Console.Write($"List as many responses you can to the following prompt.\n\n--- {prompt} ---\n\nYou may begin in: ");

        log.WriteLog($"Prompt chosen is: {prompt}");

        CountDown(10);
        Console.WriteLine(0);
        int timer = GetDuration();
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(timer);

        int itemsListed = 0;

        while (currentTime < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            itemsListed ++;
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"\n{itemsListed} items listed.");
        log.WriteLog($"User listed {itemsListed} items.");



        DisplayEndMessage();
    }

}