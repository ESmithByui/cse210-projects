using System;

public class ChecklistGoal : Goal
{
    private int bonusPoints;

    private int currentProgress;

    private int totalProgress;

    public ChecklistGoal(string name, string description, int points, bool completed, int bonus, int current, int total) : base(name, description, points, completed)
    {
        bonusPoints = bonus;
        currentProgress = current;
        totalProgress = total;
    }

    public int GetBonus()
    {
        return bonusPoints;
    }

    public int GetCurrent()
    {
        return currentProgress;
    }

    public int GetTotal()
    {
        return totalProgress;
    }

    public override void DisplayGoalShort()
    {
        Console.WriteLine($"[{currentProgress}/{totalProgress}] {base.GetName()} - {base.GetPoints()} + {bonusPoints}");
    }
    
    public override void DisplayGoalFull()
    {
        Console.WriteLine($"[{currentProgress}/{totalProgress}] {base.GetName()} - {base.GetPoints()} + {bonusPoints} | {base.GetDescription()}");
    }

    public override int MarkCompletion()
    {
        int pointReturn = 0;

        if (currentProgress < totalProgress)
        {
            currentProgress++;
            pointReturn = pointReturn + base.GetPoints();
        }
        
        if (currentProgress == totalProgress && !base.GetCompleted())
        {
            base.SetCompleted(true);
            pointReturn = pointReturn + bonusPoints;
        }

        return pointReturn;
    }

    public override string FormattedGoal()
    {
        return $"\"C\",\"{base.GetName().Replace("\"", "\"\"")}\",\"{base.GetDescription().Replace("\"", "\"\"")}\",\"{base.GetPoints()}\",\"{base.GetCompleted()}\",\"{bonusPoints}\",\"{currentProgress}\",\"{totalProgress}\"";
    }
}
