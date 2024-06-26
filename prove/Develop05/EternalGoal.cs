using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points, bool completed) : base(name, description, points, completed)
    {
        
    }

    public override string FormattedGoal()
    {
        return $"\"E\",\"{base.GetName().Replace("\"", "\"\"")}\",\"{base.GetDescription().Replace("\"", "\"\"")}\",\"{base.GetPoints()}\",\"{base.GetCompleted()}\"";
    }
}