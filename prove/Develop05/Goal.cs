using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;

public abstract class Goal
{
    private string goalName;

    private string goalDescription;

    private int goalPoints;

    private bool goalCompleted;

    public Goal(string name, string description, int points, bool completed)
    {
        goalName = name;
        goalDescription = description;
        goalPoints = points;
        goalCompleted = completed;
    }

    public string GetName()
    {
        return goalName;
    }

    public string GetDescription()
    {
        return goalDescription;
    }

    public int GetPoints()
    {
        return goalPoints;
    }

    public bool GetCompleted()
    {
        return goalCompleted;
    }

    public void SetCompleted(bool update)
    {
        goalCompleted = update;
    }

    public virtual void DisplayGoalShort()
    {
        char state = ' ';
        if (goalCompleted)
        {
            state = 'X';
        }
        Console.WriteLine($"[{state}] {goalName} - {goalPoints}");
    }

    public virtual void DisplayGoalFull()
    {
        char state = ' ';
        if (goalCompleted)
        {
            state = 'X';
        }
        Console.WriteLine($"[{state}] {goalName} - {goalPoints} | {goalDescription}");
    }

    public virtual int MarkCompletion()
    {
        if (!goalCompleted)
        {
            goalCompleted = true;
            return goalPoints;
        }
        else
        {
            return 0;
        }
        
        
    }

    public abstract string FormattedGoal();


}