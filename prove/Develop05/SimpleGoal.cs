using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points, completed)
    {
        
    }

    public override string FormattedGoal()
    {
        return $"\"S\",\"{base.GetName().Replace("\"", "\"\"")}\",\"{base.GetDescription().Replace("\"", "\"\"")}\",\"{base.GetPoints()}\",\"{base.GetCompleted()}\"";
    }
}