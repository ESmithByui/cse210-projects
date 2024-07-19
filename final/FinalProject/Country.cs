using System;
using System.Runtime.CompilerServices;

public class Country
{
    private string name;
    private Person ruler;
    private City capital;
    private List<City> cities = new List<City>();
    private CityNameGen cityName = new CityNameGen();
    private PersonGenerator personGen = new PersonGenerator();
    private int tier;
    private bool guilds;
    private int magicLvl;
    private int totalCityCount;
    private Random random = new Random();
    
    public Country(string name, int tier, bool guilds, int magicLvl)
    {
        this.name = name;
        this.tier = tier;
        this.guilds = guilds;
        this.magicLvl = magicLvl;
        ruler = personGen.GenRandomPerson();
        capital = new City(cityName.GetRandomName(), 6, personGen, guilds, magicLvl, ruler);

        if (tier == 1)
        {
            totalCityCount = random.Next(5, 9);
        }
        else if (tier == 2)
        {
            totalCityCount = random.Next(8, 13);
        }
        else if (tier == 3)
        {
            totalCityCount = random.Next(12, 17);
        }
        else if (tier == 4)
        {
            totalCityCount = random.Next(16, 25);
        }

        while (cities.Count < totalCityCount - 1)
        {
            AddCity(5);
            int newTowns = random.Next(1,4);
            if (totalCityCount - cities.Count >= newTowns * 4)
            {
                for (int i = 0; i < newTowns; i++)
                {
                    AddCity(4);
                    int newVillages = random.Next(1,4);
                    for (int p = 0; p < newVillages; p++)
                    {
                        AddCity(3);
                    }
                }
            }
            else if (totalCityCount - cities.Count >= newTowns * 2)
            {
                for (int i = 0; i < newTowns; i++)
                {
                    AddCity(4);
                    AddCity(3);
                }
            }
            else if (totalCityCount - cities.Count > 1)
            {
                AddCity(4);
                AddCity(3);
            }
            else if (totalCityCount - cities.Count > 0)
            {
                if (random.Next(2) == 0)
                {
                    AddCity(2);
                }
                else
                {
                    AddCity(1);
                }
            }

            int newHamlet = random.Next(4);
            if (totalCityCount - cities.Count >= newHamlet)
            {
                for (int i = 0; i < newHamlet; i++)
                {
                    AddCity(1);
                }
            }
            if (totalCityCount - cities.Count > 0 && random.Next(10) == 1)
            {
                AddCity(2);
            }
            
        }
    }

    public Country(string name, bool guilds, int magicLvl, int totalCityCount)
    {
        this.name = name;
        this.totalCityCount = totalCityCount;
        this.guilds = guilds;
        this.magicLvl = magicLvl;
        ruler = personGen.GenRandomPerson();
        capital = new City(cityName.GetRandomName(), 6, personGen, guilds, magicLvl, ruler);

        if (totalCityCount < 9)
        {
            tier = 1;
        }
        else if (totalCityCount < 13)
        {
            tier = 2;
        }
        else if (totalCityCount < 17)
        {
            tier = 3;
        }
        else
        {
            tier = 4;
        }

        while (cities.Count < totalCityCount - 1)
        {
            AddCity(5);
            int newTowns = random.Next(1,4);
            if (totalCityCount - 1 - cities.Count >= newTowns * 4)
            {
                for (int i = 0; i < newTowns; i++)
                {
                    AddCity(4);
                    int newVillages = random.Next(1,4);
                    for (int p = 0; p < newVillages; p++)
                    {
                        AddCity(3);
                    }
                }
            }
            else if (totalCityCount - 1 - cities.Count >= newTowns * 2)
            {
                for (int i = 0; i < newTowns; i++)
                {
                    AddCity(4);
                    AddCity(3);
                }
            }
            else if (totalCityCount - 1 - cities.Count > 1)
            {
                AddCity(4);
                AddCity(3);
            }
            else if (totalCityCount - 1 - cities.Count > 0)
            {
                if (random.Next(2) == 0)
                {
                    AddCity(2);
                }
                else
                {
                    AddCity(1);
                }
            }

            int newHamlet = random.Next(4);
            if (totalCityCount - 1 - cities.Count >= newHamlet)
            {
                for (int i = 0; i < newHamlet; i++)
                {
                    AddCity(1);
                }
            }
            if (totalCityCount - 1 - cities.Count > 0 && random.Next(10) == 1)
            {
                AddCity(2);
            }
            
        }
    }

    public string GetName()
    {
        return name;
    }

    public void DisplayCountry()
    {
        Console.WriteLine($"Country: {name}");
        int totalPopulation = capital.GetPopulation();
        foreach (City city in cities)
        {
            totalPopulation = totalPopulation + city.GetPopulation();
        }
        Console.WriteLine($"Population: {totalPopulation}");
        Console.WriteLine("Cities:");
        capital.DisplayCity();
        foreach (City city in cities)
        {
            Console.WriteLine("~~~~~~~~~~");
            city.DisplayCity();
        }
    }

    public List<string> FormatCountry()
    {
        List<string> formattedString = new List<string>();
        
        formattedString.Add($"Country: {name}");
        formattedString.Add($"Ruler: {ruler.GetFirstName()} {ruler.GetLastName()}");
        formattedString.Add($"         {ruler.GetRace()}, {ruler.GetGender()}");
        int totalPopulation = capital.GetPopulation();
        foreach (City city in cities)
        {
            totalPopulation = totalPopulation + city.GetPopulation();
        }
        formattedString.Add($"Population: {totalPopulation}");
        formattedString.Add($"Capital:");
        int capitalMaxStringLength = capital.FormatCity().Max(str => str.Length);
        string capitalSpacer = "";
        for (int i = 0; i < capitalMaxStringLength; i++)
        {
            capitalSpacer = $"{capitalSpacer}~";
        }
        formattedString.Add(capitalSpacer);
        foreach (string line in capital.FormatCity())
        {
            formattedString.Add($"|   {line}");
        }
        formattedString.Add(capitalSpacer);
        formattedString.Add($"Cities:");
        foreach (City city in cities)
        {
            int maxStringLength = city.FormatCity().Max(str => str.Length);
            string spacer = "";
            for (int i = 0; i < maxStringLength; i++)
            {
                spacer = $"{spacer}~";
            }
            formattedString.Add(spacer);
            foreach (string line in city.FormatCity())
            {
                formattedString.Add($"|   {line}");
            }
            formattedString.Add(spacer);

        }

        return formattedString;
    }

    public void AddCity(int cityTier)
    {
        cities.Add(new City(cityName.GetRandomName(), cityTier, personGen, guilds, magicLvl));
    }

}