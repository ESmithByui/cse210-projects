using System;
using System.Security.Cryptography.X509Certificates;

public class GoalList
{
    private List<List<Goal>> allGoals = new List<List<Goal>>{
        new List<Goal>(),
        new List<Goal>(),
        new List<Goal>()
    };

    private string goalFile;


    private Random random = new Random();

    public GoalList(string goalFileName)
    {
        goalFile = goalFileName;

        LoadGoals();
    }

    public GoalList(string goalFileName, List<List<Goal>> newGoals)
    {
        goalFile = goalFileName;

        allGoals = newGoals;

        SaveGoals();
    }


    public Goal RandomGoal(int index)
    {
        return allGoals[index][random.Next(allGoals[index].Count)];
    }
    
    public void AddGoal(Goal goal)
    {
        if (goal is EternalGoal)
        {
            allGoals[0].Add(goal);
        }
        else if (goal is SimpleGoal)
        {
            allGoals[1].Add(goal);
        }
        else if (goal is ChecklistGoal)
        {
            allGoals[2].Add(goal);
        }
        SaveGoals();
    }

    public void SaveGoals()
    {
        using(StreamWriter writer = new StreamWriter(goalFile))
        {
            writer.WriteLine("Complete Goal List");

            foreach(List<Goal> goals in allGoals)
            {
                foreach(Goal goal in goals)
                {
                    writer.WriteLine(goal.FormattedGoal());
                }
            }

           
        }

    }

    private void LoadGoals()
    {
        using (var reader = new StreamReader(goalFile))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                
                List<string> parsed = ParseCsvLine(line);

                if (parsed[0] == "E")
                {
                    allGoals[0].Add(new EternalGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), false));
                }
                else if (parsed[0] == "S")
                {
                    allGoals[1].Add(new SimpleGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), false));
                }
                else if (parsed[0] == "C")
                {
                    allGoals[2].Add(new ChecklistGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), false, int.Parse(parsed[5]), 0, int.Parse(parsed[7])));
                }
            }
        }

    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        int startIndex = 0;

        for(int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(line.Substring(startIndex, i - startIndex));

                startIndex = i + 1;
            }
        }

        fields.Add(line.Substring(startIndex));

        List<string> parsedFields = new List<string>();

        foreach(string field in fields)
        {
            parsedFields.Add(field.Substring(1, field.Length - 2));
        }

        return parsedFields;
    }

}