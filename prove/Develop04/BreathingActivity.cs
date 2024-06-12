using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }

    public override void RunActivity()
    {
        DisplayStartMessage();
        
        Console.Clear();
        int time = GetDuration();
        while(time > 0)
        {
            int startPause = 4;
            int endPause = 6;
            if(time < 14)
            {
                startPause = Convert.ToInt32(Math.Floor(Convert.ToDouble(time) / 2)) - 1;
                endPause = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(time) / 2)) + 1;
            }
            Console.WriteLine("Breath in");
            CountDown(startPause);
            Console.WriteLine("Breath out");
            CountDown(endPause);
            time = time - startPause - endPause;
        }
        DisplayEndMessage();
    }
}