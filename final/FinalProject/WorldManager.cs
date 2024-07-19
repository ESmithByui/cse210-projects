using System;
using System.IO.Enumeration;
using System.Security.Cryptography;

public class WorldManager
{
    private Country country;
    private City city;
    private string goal;
    private bool guilds = true;
    private int magicLvl = 3;
    private CountryNameGen countryNameGen = new CountryNameGen();
    private CityNameGen cityNameGen = new CityNameGen();
    public WorldManager(string goal)
    {
        this.goal = goal;
    }

    public void Setup()
    {
        Console.Clear();
        Console.WriteLine($"Do you want to diable guilds for your {goal}?");
        Console.WriteLine($"This will disable Guildhouses and Magic Guilds in your {goal}");
        Console.WriteLine("1. Disable");
        Console.WriteLine("2. Continue");
        Console.Write("Choose an option: ");
        if (Console.ReadLine() == "1")
        {
            guilds = false;
        }
        Thread.Sleep(3000);

        Console.Clear();
        Console.WriteLine($"What level of magic do you want in this world?");
        Console.WriteLine($"This will prevent magic based locations from generating in your {goal}");
        Console.WriteLine("1. No magic");
        Console.WriteLine("2. Some magic");
        Console.WriteLine("3. More magic");
        Console.Write("Choose an option: ");
        if (int.TryParse(Console.ReadLine(), out magicLvl))
        {
            Console.WriteLine("Magic Level Set");
            Thread.Sleep(3000);
        }

        string name = "Blankety Blank";
        Console.Clear();
        Console.WriteLine($"Do you want to name your {goal}?");
        Console.WriteLine($"1. Name the {goal}");
        Console.WriteLine($"2. Randomly generate a name");
        Console.Write("Choose an option: ");
        if (Console.ReadLine() == "1")
        {
            Console.Write($"What do you want the name of your {goal} to be? ");
            name = Console.ReadLine();
        }
        else
        {
            if (goal == "country")
            {
                name = countryNameGen.GetRandomName();
            }
            else
            {
                name = cityNameGen.GetRandomName();
            }
        }
        Console.WriteLine($"\nName of {goal} set to {name}");
        Thread.Sleep(3000);

        Console.Clear();
        if (goal == "country")
        {
            Console.WriteLine($"Select the size of your {goal}");
            Console.WriteLine("1. Small (5-8)");
            Console.WriteLine("2. Medium (8-12)");
            Console.WriteLine("3. Large (12-16)");
            Console.WriteLine("4. Largest (16-24)");
            Console.WriteLine("5. Select your own");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            int tier = 2;
            int totalCityCount = 0;
            if (int.TryParse(choice, out tier))
            {
                if (tier == 5)
                {
                    Console.WriteLine("Enter how many cities you want in your country: ");
                    if (int.TryParse(Console.ReadLine(), out totalCityCount))
                    {
                        if (totalCityCount < 1)
                        {
                            Console.WriteLine("Invalid number, reverting to presets");
                            tier = 2;
                        }
                    }
                }
                else if (tier < 1)
                {
                    tier = 2;
                }
            }
            else
            {
                tier = 2;
            }

            if (totalCityCount < 1)
            {
                country = new Country(name, tier, guilds, magicLvl);
            }
            else
            {
                country = new Country(name, guilds, magicLvl, totalCityCount);
            }
        }
        else
        {
            Console.WriteLine($"Select the size of your {goal}");
            Console.WriteLine("1. Hamlet (1)");
            Console.WriteLine("2. Commune (2)");
            Console.WriteLine("3. Village (3)");
            Console.WriteLine("4. Town (4)");
            Console.WriteLine("5. City (5)");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            int tier = 5;
            if (int.TryParse(choice, out tier))
            {
                if (tier < 1)
                {
                    tier = 1;
                }
            }
            else
            {
                tier = 5;
            }

            city = new City(name, tier, new PersonGenerator(), guilds, magicLvl);
        }


        Console.WriteLine($"Creating {goal}...");
        Thread.Sleep (5000);
        Console.WriteLine($"Created {goal}");
        Thread.Sleep(3000);
    }

    public void DisplaySummary()
    {
        if (goal == "country")
        {
            country.DisplayCountry();
        }
        else
        {
            city.DisplayCity();
        }
    }

    public void DisplayFull()
    {
        Console.Clear();
        List<string> displayString;
        if (goal == "country")
        {
            displayString = country.FormatCountry();
        }
        else
        {
            displayString = city.FormatCity();
        }

        foreach (string line in displayString)
        {
            Console.WriteLine(line);
        }
    }

    public void Export()
    {
        string name = "Blankety Blank";
        List<string> exportStrings;
        if (goal == "country")
        {
            name = country.GetName().ToLower().Replace(" ", "_");
            exportStrings = country.FormatCountry();
        }
        else
        {
            name = city.GetName().ToLower().Replace(" ", "_");
            exportStrings = city.FormatCity();
        }

        string fileName = $"{name}_{goal}.txt";
        //Avibility to save to downloads
        //string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        //string filePath = Path.Combine(downloadPath, fileName);
        string filePath = Path.Combine("savedFiles", fileName);
        int count = 0;
        while (File.Exists(filePath))
        {
            count ++;
            fileName = $"{name}_{goal}_{count}.txt";
            filePath = Path.Combine("savedFiles", fileName);
        }

        using(StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach(string line in exportStrings)
            {
                writer.WriteLine(line);
            }
        }
        Console.WriteLine($"Saved to {fileName}");
        Thread.Sleep(5000);
    }
}