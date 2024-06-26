using System;
using System.Data;
using System.Xml.Serialization;

public class GoalManager
{
    private List<List<Goal>> currentGoals = new List<List<Goal>>{
        new List<Goal>(),
        new List<Goal>(),
        new List<Goal>()
    };

    private List<List<Goal>> goalBoard = new List<List<Goal>>{
        new List<Goal>(),
        new List<Goal>(),
        new List<Goal>()
    };

    private User user;

    private GoalList allGoals;

    private int refreshCount;

    private DateTime lastOpenDate;

    private int[] totalCurrentGoals = new int[]{3, 3, 2};

    private int[] totalBoardGoals = new int[]{3, 3, 3};

    public GoalManager(string goalFile, string userFile)
    {
        if (!File.Exists(goalFile))
        {
            List<List<Goal>> newGoals = new List<List<Goal>>{
                new List<Goal>(),
                new List<Goal>(),
                new List<Goal>()
            };

            for (int i = 0; i < 3; i++)
            {
                while (newGoals[i].Count < (totalCurrentGoals[i] + totalBoardGoals[i]))
                {
                    Console.Clear();
                    newGoals[i].Add(CreateGoal(i));
                }
                
            }

            allGoals = new GoalList(goalFile, newGoals);
        }
        else
        {
            allGoals = new GoalList(goalFile);
        }
        
        if (!File.Exists(userFile))
        {
            Console.Clear();
            Console.Write("Enter a new user name: ");
            refreshCount = 3;
            lastOpenDate = DateTime.Now.AddDays(-2);
            string userName = Console.ReadLine();
            user = new User(userFile, userName);

            RefillGoals();

            user.SaveUser(currentGoals, goalBoard, refreshCount);
        }
        else
        {
            LoadUser(userFile);
            DisplayGoals();
            RefillGoals();
        }


    }
    
    public void DisplayGoals()
    {
        Console.WriteLine("~~~Active Goals~~~");

        Console.WriteLine("<<<Eternal Goals>>>");
        foreach(Goal goal in currentGoals[0])
        {
            Console.WriteLine("---------------");
            goal.DisplayGoalFull();
        }
        Console.WriteLine();

        Console.WriteLine("<<<Simple Goals>>>");
        foreach(Goal goal in currentGoals[1])
        {
            Console.WriteLine("---------------");;
            goal.DisplayGoalFull();
        }
        Console.WriteLine();


        Console.WriteLine("<<<Checklist Goals>>>");
        foreach(Goal goal in currentGoals[2])
        {
            Console.WriteLine("---------------");
            goal.DisplayGoalFull();
        }
    }

    public void DisplayGoalsSection(int index)
    {
        int count = 0;

        if (index == 0)
        {
            Console.WriteLine("<<<Eternal Goals>>>");
        }
        else if (index == 1)
        {
            Console.WriteLine("<<<Simple Goals>>>");
        }
        else if (index == 2)
        {
            Console.WriteLine("<<<Checklist Goals>>>");
        }

        foreach(Goal goal in currentGoals[index])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalShort();
        }
    }

    public void DisplayGoalList()
    {
        Console.WriteLine("~~~Active Goals~~~");
        
        int count = 0;

        Console.WriteLine("<<<Eternal Goals>>>");
        foreach(Goal goal in currentGoals[0])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalShort();
        }
        Console.WriteLine();

        Console.WriteLine("<<<Simple Goals>>>");
        foreach(Goal goal in currentGoals[1])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalShort();
        }
        Console.WriteLine();


        Console.WriteLine("<<<Checklist Goals>>>");
        foreach(Goal goal in currentGoals[2])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalShort();
        }
    }

    public void DisplayGoalBoard()
    {
        Console.WriteLine("~~~Goal Board~~~");
        
        int count = 0;

        Console.WriteLine("<<<Eternal Goals>>>");
        foreach(Goal goal in goalBoard[0])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalFull();
        }
        Console.WriteLine();

        Console.WriteLine("<<<Simple Goals>>>");
        foreach(Goal goal in goalBoard[1])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalFull();
        }
        Console.WriteLine();


        Console.WriteLine("<<<Checklist Goals>>>");
        foreach(Goal goal in goalBoard[2])
        {
            Console.WriteLine("---------------");
            count ++;
            Console.Write($"{count}. ");
            goal.DisplayGoalFull();
        }
    }

    private Goal SelectBoardGoal(int index)
    {
        int eternal = goalBoard[0].Count;
        int simple = goalBoard[1].Count + eternal;
        int checklist = goalBoard[2].Count + simple;

        if (index <= eternal)
        {
            return goalBoard[0][index - 1];
        }
        else if (index <= simple)
        {
            return goalBoard[1][index - 1 - eternal];
        }
        else if (index <= checklist)
        {
            return goalBoard[2][index - 1 - simple];
        }
        else
        {
            Console.WriteLine("Default to 1");
            return goalBoard[0][0];
        }
    }

    private Goal SelectCurrentGoal(int index)
    {
        int eternal = currentGoals[0].Count;
        int simple = currentGoals[1].Count + eternal;
        int checklist = currentGoals[2].Count + simple;

        if (index <= eternal)
        {
            return currentGoals[0][index - 1];
        }
        else if (index <= simple)
        {
            return currentGoals[1][index - 1 - eternal];
        }
        else if (index <= checklist)
        {
            return currentGoals[2][index - 1 - simple];
        }
        else
        {
            Console.WriteLine("Default to 1");
            return currentGoals[0][0];
        }
    }

    private void CreateGoalBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            goalBoard[i].Clear();

            while(goalBoard[i].Count < totalBoardGoals[i])
            {
                Goal tempGoal = allGoals.RandomGoal(i);
                if (!goalBoard[i].Any(g => g.GetName() == tempGoal.GetName()) && !currentGoals[i].Any(g => g.GetName() == tempGoal.GetName()))
                {
                    goalBoard[i].Add(tempGoal);
                }
            }
        }

    }

    private void LoadUser(string userFile)
    {
        using (var reader = new StreamReader(userFile))
        {

            reader.ReadLine();

            string name = reader.ReadLine();
            int points = int.Parse(reader.ReadLine());
            int threshold = int.Parse(reader.ReadLine());
            string levelClass = reader.ReadLine();
            string levelTier = reader.ReadLine();
            int levelPrestige = int.Parse(reader.ReadLine());

            user = new User(userFile, name, points, threshold, levelClass, levelTier, levelPrestige);

            lastOpenDate = DateTime.Parse(reader.ReadLine());
            refreshCount = int.Parse(reader.ReadLine());

            reader.ReadLine();
            bool isBoard = false;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == "Goal Board")
                {
                    isBoard = true;
                    line = reader.ReadLine();
                }

                if (isBoard)
                {
                    List<string> parsed = ParseCsvLine(line);
                    bool tempBool = false;
                    if (parsed[4] == "true")
                    {
                        tempBool = true;
                    }

                    if (parsed[0] == "E")
                    {
                        goalBoard[0].Add(new EternalGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), tempBool));
                    }
                    else if (parsed[0] == "S")
                    {
                        goalBoard[1].Add(new SimpleGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), tempBool));
                    }
                    else if (parsed[0] == "C")
                    {
                        goalBoard[2].Add(new ChecklistGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), tempBool, int.Parse(parsed[5]), int.Parse(parsed[6]), int.Parse(parsed[7])));
                    }
                }
                else
                {
                    List<string> parsed = ParseCsvLine(line);
                    bool tempBool = false;
                    if (parsed[4] == "True")
                    {
                        tempBool = true;
                    }

                    if (parsed[0] == "E")
                    {
                        currentGoals[0].Add(new EternalGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), tempBool));
                    }
                    else if (parsed[0] == "S")
                    {
                        currentGoals[1].Add(new SimpleGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), tempBool));
                    }
                    else if (parsed[0] == "C")
                    {
                        currentGoals[2].Add(new ChecklistGoal(parsed[1].Replace("\"\"", "\""), parsed[2].Replace("\"\"", "\""), int.Parse(parsed[3]), tempBool, int.Parse(parsed[5]), int.Parse(parsed[6]), int.Parse(parsed[7])));
                    }
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

    public void DisplayUser()
    {
        user.DisplayUser();
    }

    public void RefillGoals()
    {
        if ((DateTime.Now - lastOpenDate).TotalDays >= 1)
        {
            lastOpenDate = DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy"));

            for (int i = 0; i < 3; i++)
            {
                List<Goal> toDelete = new List<Goal>();
                for (int g = 0; g < currentGoals[i].Count; g++)
                {
                    Console.WriteLine("Test");
                    if (currentGoals[i][g].GetCompleted())
                    {
                        bool goalAdded = false;
                        while (!goalAdded && currentGoals[i].Count <= (totalCurrentGoals[i] + toDelete.Count))
                        {
                            Goal tempGoal = allGoals.RandomGoal(i);
                            if (!currentGoals[i].Any(g => g.GetName() == tempGoal.GetName()))
                            {
                                currentGoals[i].Add(tempGoal);
                                goalAdded = true;
                            }
                        }
                        toDelete.Add(currentGoals[i][g]);
                    }
                }

                foreach(Goal goal in toDelete)
                {
                    currentGoals[i].Remove(goal);
                }

                while (currentGoals[i].Count < totalCurrentGoals[i])
                {
                    Goal tempGoal = allGoals.RandomGoal(i);
                    if (!currentGoals[i].Any(g => g.GetName() == tempGoal.GetName()))
                    {
                        currentGoals[i].Add(tempGoal);
                    }
                }
            }

            CreateGoalBoard();
            refreshCount = 3;
            user.SaveUser(currentGoals, goalBoard, refreshCount);
        }
    }

    public void SwitchGoals()
    {   
        Console.Clear();
        Console.WriteLine($"You currently have {refreshCount} refreshes:");
        if (refreshCount == 0)
        {
            Console.WriteLine($"Wait until tomorrow to get more.");
        }
        else
        {
            Console.WriteLine();
            DisplayGoalBoard();
            Console.Write("\nSelect which goal you'd like to switch with a current goal: ");
            Goal tempBoardGoal = SelectBoardGoal(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            int goalType = 0;
            if (tempBoardGoal is SimpleGoal)
            {
                goalType = 1;
            }
            else if (tempBoardGoal is ChecklistGoal)
            {
                goalType = 2;
            }
            Console.Clear();
            DisplayGoalsSection(goalType);
            Console.Write("\nSelect which goal you'd like to replace: ");
            int currentChoice = int.Parse(Console.ReadLine()) - 1;
            Goal tempCurrentGoal = currentGoals[goalType][currentChoice];

            Console.WriteLine($"\nYou'd like to replace {tempCurrentGoal.GetName()} with {tempBoardGoal.GetName()}? Type CONFIRM to confirm:");
            if (Console.ReadLine() == "CONFIRM")
            {
                currentGoals[goalType].RemoveAt(currentChoice);
                currentGoals[goalType].Add(tempBoardGoal);
                goalBoard[goalType].Remove(tempBoardGoal);
                refreshCount--;
                user.SaveUser(currentGoals, goalBoard, refreshCount);

                Console.WriteLine($"Goal has been switched. You now have {refreshCount} refreshes remaining.");
            }
            else
            {
                Console.WriteLine("No changes were made.");
            }
            
        }
    }

    public void MarkCompletion()
    {
        Console.Clear();
        DisplayGoalList();
        Console.Write("\nSelect which goal you'd like to mark completion in: ");
        
        Goal tempCurrentGoal = SelectCurrentGoal(int.Parse(Console.ReadLine()));
        Console.Write($"Are you sure you want to mark {tempCurrentGoal.GetName()}? (y/n): ");
        if (Console.ReadLine().ToLower() == "y")
        {
            user.AdjustUserPoints(tempCurrentGoal.MarkCompletion());
            user.SaveUser(currentGoals, goalBoard, refreshCount);
            Console.WriteLine("Goal marked completed.");
        }
        else
        {
            Console.WriteLine("No changes were made.");
        }
    }

    private Goal CreateGoal(int goalType)
    {
        if (goalType == 0)
        {
            Console.Write("Enter eternal goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter goal points: ");
            int points = int.Parse(Console.ReadLine());
            return new EternalGoal(name, description, points, false);
        }
        else if (goalType == 1)
        {
            Console.Write("Enter simple goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter goal points: ");
            int points = int.Parse(Console.ReadLine());
            return new SimpleGoal(name, description, points, false);
        }
        else
        {
            Console.Write("Enter checklistgoal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter number of times to complete goal: ");
            int totalProgress = int.Parse(Console.ReadLine());
            Console.Write("Enter goal points per completion: ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("Enter goal points for full completion: ");
            int bonus = int.Parse(Console.ReadLine());
            
            return new ChecklistGoal(name, description, points, false, bonus, 0, totalProgress);
        }
    }

    public void AddNewGoal()
    {
        Console.Clear();
        Console.WriteLine("1. Eternal\n2. Simple\n3. Checklist");
        Console.Write("What kind of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine()) - 1;
        Goal tempGoal = CreateGoal(goalType);
        allGoals.AddGoal(tempGoal);

        if (refreshCount > 0)
        {
            Console.Write($"Would you like to switch this goal into your current goals? This would use 1 of your {refreshCount} refreshes. (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                DisplayGoalsSection(goalType);
                Console.Write("\nSelect which goal you'd like to replace: ");
                int currentChoice = int.Parse(Console.ReadLine()) - 1;
                Goal tempCurrentGoal = currentGoals[goalType][currentChoice];

                Console.WriteLine($"\nYou'd like to replace {tempCurrentGoal.GetName()} with {tempGoal.GetName()}? Type CONFIRM to confirm:");
                if (Console.ReadLine() == "CONFIRM")
                {
                    currentGoals[goalType].RemoveAt(currentChoice);
                    currentGoals[goalType].Add(tempGoal);
                    goalBoard[goalType].Remove(tempGoal);
                    refreshCount--;
                    user.SaveUser(currentGoals, goalBoard, refreshCount);

                    Console.WriteLine($"Goal has been switched. You now have {refreshCount} refreshes remaining."); 
                }
                else
                {
                    Console.WriteLine("No changes were made.");
                }
            }
        }
    }
}

