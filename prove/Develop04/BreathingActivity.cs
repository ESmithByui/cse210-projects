using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(CreateLog log) : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", log)
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
            Console.Write("Breath in...");
            CountDown(startPause);
            Console.Write("\nBreath out...");
            CountDown(endPause);
            time = time - startPause - endPause;
            Console.WriteLine();
        }
        DisplayEndMessage();
    }
}