using System;

public abstract class Activity
{
    private string activityTitle;
    private string activityDescription;
    private int duration = 0;

    public Activity(string title, string description)
    {
        activityTitle = title;
        activityDescription = description;
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityTitle}.\n");
        Console.WriteLine(activityDescription);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin your session.");
        PauseAnimation(7);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("Well done!\n");
        PauseAnimation(7);
        Console.WriteLine($"You've completed {duration} seconds of the {activityTitle}");
        PauseAnimation(7);
    }

    public int GetDuration()
    {
        return duration;
    }

    public void SpinAnimation(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void CountDown(int count)
    {
        for(int i = count; i > 0; i--)
        {
            int length = i.ToString().Length;
            Console.Write(i);
            Thread.Sleep(1000);
            for(int l = length; l > 0; l--)
            {
                Console.Write("\b \b");
            }

            
        }
    }

    public void PauseAnimation(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Console.Write(".  ");
            Thread.Sleep(250);
            Console.Write("\b\b\b.. ");
            Thread.Sleep(250);
            Console.Write("\b\b\b...");
            Thread.Sleep(250);
            Console.Write("\b\b\b   ");
            Thread.Sleep(250);
            Console.Write("\b\b\b");
        }
        
    }

    public string ChooseString(string[] source, List<string> check, Random random)
    {
        if (source.Length == check.Count)
        {
            string lastInput = check.Last();
            check.Clear();
            check.Add(lastInput);
        }

        bool match = true;
        int randomInt = 0;
        do
        {
            randomInt = random.Next(source.Length);
            if(!check.Contains(source[randomInt]))
            {
                check.Add(source[randomInt]);
                match = false;
            }
        }while(match);

        return source[randomInt];
    }

    public abstract void RunActivity();
}