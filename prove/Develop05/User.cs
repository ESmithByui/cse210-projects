using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

public class User
{
    private string userFile;

    private string userName;

    private int userPoints;

    private int userLevelThreshold;

    private string userLevelClass;

    private string userLevelTier;

    private int userLevelPrestige;

    private List<string> classes = new List<string>{
        "Beginner",
        "Casual",
        "Expert",
        "Master",
        "Knight",
        "Ninja",
        "Guru",
        "Wizard",
        "King",
        "Dragon"
    };

    private List<string> tiers = new List<string>{
        "Weak",
        "Normal",
        "Growing",
        "Strong",
        "Flaming",
        "Powerful",
        "Super",
        "Titanic",
        "Ancient",
        "Abyss"
    };

    public User(string userFileName, string name, int points, int levelThreshold, string levelClass, string levelTier, int levelPrestige)
    {
        userFile = userFileName;
        userName = name;
        userPoints = points;
        userLevelThreshold = levelThreshold;
        userLevelClass = levelClass;
        userLevelTier = levelTier;
        userLevelPrestige = levelPrestige;

    }

    public User(string userFileName, string name)
    {
        userFile = userFileName;
        userName = name;
        userPoints = 0;
        userLevelThreshold = 100;
        userLevelClass = classes[0];
        userLevelTier = tiers[0];
        userLevelPrestige = 0;
    }

    private void DetermineLevel()
    {
        while (userPoints >= userLevelThreshold)
        {
            userPoints = userPoints - userLevelThreshold;
            if (tiers.IndexOf(userLevelTier) < 9)
            {
                userLevelTier = tiers[tiers.IndexOf(userLevelTier) + 1];
            }
            else if (tiers.IndexOf(userLevelTier) >= 9 && classes.IndexOf(userLevelClass) >= 9)
            {
                userLevelPrestige++;
                userLevelThreshold = userLevelThreshold + (userLevelPrestige * 100);
            }
            else if (tiers.IndexOf(userLevelTier) >= 9)
            {
                userLevelThreshold = userLevelThreshold + 100;
                userLevelTier = tiers[0];
                userLevelClass = classes[classes.IndexOf(userLevelClass) + 1];
            }
        }
    }

    public void AdjustUserPoints(int points)
    {
        userPoints = userPoints + points;
        DetermineLevel();
    }

    public void SaveUser(List<List<Goal>> currentGoals, List<List<Goal>> goalBoard, int refreshCount)
    {
        using(StreamWriter writer = new StreamWriter(userFile))
        {
            writer.WriteLine("User File");

            writer.WriteLine(userName);

            writer.WriteLine(userPoints);

            writer.WriteLine(userLevelThreshold);

            writer.WriteLine(userLevelClass);

            writer.WriteLine(userLevelTier);

            writer.WriteLine(userLevelPrestige);

            writer.WriteLine(DateTime.Now.ToString("MM-dd-yyyy"));

            writer.WriteLine(refreshCount);

            writer.WriteLine("Current Goals");

            foreach(List<Goal> goals in currentGoals)
            {
                foreach(Goal goal in goals)
                {
                    writer.WriteLine(goal.FormattedGoal());
                }
            }

            writer.WriteLine("Goal Board");

            foreach(List<Goal> goals in goalBoard)
            {
                foreach(Goal goal in goals)
                {
                    writer.WriteLine(goal.FormattedGoal());
                }
            }
        }
    }

    public void DisplayUser()
    {
        string prestige = "";
        if (userLevelPrestige > 0)
        {
            prestige = $" +{userLevelPrestige}";
        }

        Console.WriteLine($"{userName}, {userLevelTier} {userLevelClass}{prestige} | {userPoints}/{userLevelThreshold}");
    }


}