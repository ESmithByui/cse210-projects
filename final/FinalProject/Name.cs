using System;
using System.Reflection.Metadata.Ecma335;

public class Name
{
    private Random random = new Random();
    private string[] nameFiles = new string[]
    {
        "personNames/human_last_names.txt",
        "personNames/human_male_first_names.txt",
        "personNames/human_female_first_names.txt",
        "personNames/dwarf_last_names.txt",
        "personNames/dwarf_male_first_names.txt",
        "personNames/dwarf_female_first_names.txt",
        "personNames/elf_last_names.txt",
        "personNames/elf_male_first_names.txt",
        "personNames/elf_female_first_names.txt",
        "personNames/halfling_last_names.txt",
        "personNames/halfling_male_first_names.txt",
        "personNames/halfling_female_first_names.txt",
        "personNames/dragonborn_last_names.txt",
        "personNames/dragonborn_male_first_names.txt",
        "personNames/dragonborn_female_first_names.txt",
        "personNames/gnome_last_names.txt",
        "personNames/gnome_male_first_names.txt",
        "personNames/gnome_female_first_names.txt",
        "personNames/orc_male_first_names.txt",
        "personNames/orc_female_first_names.txt",
        "personNames/tiefling_male_first_names.txt",
        "personNames/tiefling_female_first_names.txt"
    };
    private string[] races = new string[]
    {
        "Human",
        "Dwarf",
        "Elf",
        "Halfling",
        "DragonBorn",
        "Gnome",
        "Half-Elf",
        "Half-Orc",
        "Tiefling"
    };
    private List<string> humanLastNames = new List<string>();
    private List<string> humanMaleFirstNames = new List<string>();
    private List<string> humanFemaleFirstNames = new List<string>();
    private List<string> dwarfLastNames = new List<string>();
    private List<string> dwarfMaleFirstNames = new List<string>();
    private List<string> dwarfFemaleFirstNames = new List<string>();
    private List<string> elfLastNames = new List<string>();
    private List<string> elfMaleFirstNames = new List<string>();
    private List<string> elfFemaleFirstNames = new List<string>();
    private List<string> halflingLastNames = new List<string>();
    private List<string> halflingMaleFirstNames = new List<string>();
    private List<string> halflingFemaleFirstNames = new List<string>();
    private List<string> dragonbornLastNames = new List<string>();
    private List<string> dragonbornMaleFirstNames = new List<string>();
    private List<string> dragonbornFemaleFirstNames = new List<string>();
    private List<string> gnomeLastNames = new List<string>();
    private List<string> gnomeMaleFirstNames = new List<string>();
    private List<string> gnomeFemaleFirstNames = new List<string>();
    private List<string> orcMaleFirstNames = new List<string>();
    private List<string> orcFemaleFirstNames = new List<string>();
    private List<string> tieflingMaleFirstNames = new List<string>();
    private List<string> tieflingFemaleFirstNames = new List<string>();

    public Name()
    {

        LoadFile(nameFiles[0], humanLastNames);
        LoadFile(nameFiles[1], humanMaleFirstNames);
        LoadFile(nameFiles[2], humanFemaleFirstNames);
        //LoadFile(nameFiles[3], dwarfLastNames);
        //LoadFile(nameFiles[4], dwarfMaleFirstNames);
        //LoadFile(nameFiles[5], dwarfFemaleFirstNames);
        //LoadFile(nameFiles[6], elfLastNames);
        //LoadFile(nameFiles[7], elfMaleFirstNames);
        //LoadFile(nameFiles[8], elfFemaleFirstNames);
        //LoadFile(nameFiles[9], halflingLastNames);
        //LoadFile(nameFiles[10], halflingMaleFirstNames);
        //LoadFile(nameFiles[11], halflingFemaleFirstNames);
        //LoadFile(nameFiles[12], dragonbornLastNames);
        //LoadFile(nameFiles[13], dragonbornMaleFirstNames);
        //LoadFile(nameFiles[14], dragonbornFemaleFirstNames);
        //LoadFile(nameFiles[15], gnomeLastNames);
        //LoadFile(nameFiles[16], gnomeMaleFirstNames);
        //LoadFile(nameFiles[17], gnomeFemaleFirstNames);
        //LoadFile(nameFiles[18], orcMaleFirstNames);
        //LoadFile(nameFiles[19], orcFemaleFirstNames);
        //LoadFile(nameFiles[20], tieflingMaleFirstNames);
        //LoadFile(nameFiles[21], tieflingFemaleFirstNames);
    }

    public void LoadFile(string fileName, List<string> returnList)
    {
        using (var reader = new StreamReader(fileName))
        {

            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line.Length > 0)
                {
                    returnList.Add(line);
                }
            }
        }
    }

    public string GetRace()
    {
        return "Human";
        //return races[random.Next(races.Length)];
    }

    public string GetGender()
    {
        if (random.Next(2) == 0)
        {
            return "M";
        }
        else
        {
            return "F";
        }
    }

    public string GetLastName(string race)
    {
        if (race == "Human")
        {
            return humanLastNames[random.Next(humanLastNames.Count)];
        }
        else if (race == "Dwarf")
        {
            return dwarfLastNames[random.Next(dwarfLastNames.Count)];
        }
        else if (race == "Elf")
        {
            return elfLastNames[random.Next(elfLastNames.Count)];
        }
        else if (race == "Halfling")
        {
            return halflingLastNames[random.Next(halflingLastNames.Count)];
        }
        else if (race == "Dragonborn")
        {
            return dragonbornLastNames[random.Next(dragonbornLastNames.Count)];
        }
        else if (race == "Gnome")
        {
            return gnomeLastNames[random.Next(gnomeLastNames.Count)];
        }
        else if (race == "Half-Elf")
        {
            if (random.Next(2) == 0)
            {
                return humanLastNames[random.Next(humanLastNames.Count)];
            }
            else
            {
                return elfLastNames[random.Next(elfLastNames.Count)];
            }
        }
        else if (race == "Half-Orc")
        {
            if (random.Next(2) == 0)
            {
                return humanLastNames[random.Next(humanLastNames.Count)];
            }
            else
            {
                return "";
            }
        }
        else if (race == "Tiefling")
        {
            return "";
        }
        else
        {
            return "Doe";
        }
    }

    public string GetFirstName(string race, string gender)
    {
        if (race == "Human")
        {
            if (gender == "M")
            {
                return humanMaleFirstNames[random.Next(humanMaleFirstNames.Count)];
            }
            else
            {
                return humanFemaleFirstNames[random.Next(humanFemaleFirstNames.Count)];
            }
        }
        else if (race == "Dwarf")
        {
            if (gender == "M")
            {
                return dwarfMaleFirstNames[random.Next(dwarfMaleFirstNames.Count)];
            }
            else
            {
                return dwarfFemaleFirstNames[random.Next(dwarfFemaleFirstNames.Count)];
            }
        }
        else if (race == "Elf")
        {
            if (gender == "M")
            {
                return elfMaleFirstNames[random.Next(elfMaleFirstNames.Count)];
            }
            else
            {
                return elfFemaleFirstNames[random.Next(elfFemaleFirstNames.Count)];
            }
        }
        else if (race == "Halfling")
        {
            if (gender == "M")
            {
                return halflingMaleFirstNames[random.Next(halflingMaleFirstNames.Count)];
            }
            else
            {
                return halflingFemaleFirstNames[random.Next(halflingFemaleFirstNames.Count)];
            }
        }
        else if (race == "Dragonborn")
        {
            if (gender == "M")
            {
                return dwarfMaleFirstNames[random.Next(dwarfMaleFirstNames.Count)];
            }
            else
            {
                return dwarfFemaleFirstNames[random.Next(dwarfFemaleFirstNames.Count)];
            }
        }
        else if (race == "Gnome")
        {
            if (gender == "M")
            {
                return gnomeMaleFirstNames[random.Next(gnomeMaleFirstNames.Count)];
            }
            else
            {
                return gnomeFemaleFirstNames[random.Next(gnomeFemaleFirstNames.Count)];
            }
        }
        else if (race == "Half-Elf")
        {
            if (random.Next(2) == 0)
            {   
                if (gender == "M")
                {
                    return humanMaleFirstNames[random.Next(humanMaleFirstNames.Count)];
                }
                else
                {
                    return humanFemaleFirstNames[random.Next(humanFemaleFirstNames.Count)];
                }
            }
            else
            {   
                if (gender == "M")
                {
                    return elfMaleFirstNames[random.Next(elfMaleFirstNames.Count)];
                }
                else
                {
                    return elfFemaleFirstNames[random.Next(elfFemaleFirstNames.Count)];
                }
            }
        }
        else if (race == "Half-Orc")
        {
            if (random.Next(2) == 0)
            {   
                if (gender == "M")
                {
                    return humanMaleFirstNames[random.Next(humanMaleFirstNames.Count)];
                }
                else
                {
                    return humanFemaleFirstNames[random.Next(humanFemaleFirstNames.Count)];
                }
            }
            else
            {   
                if (gender == "M")
                {
                    return orcMaleFirstNames[random.Next(orcMaleFirstNames.Count)];
                }
                else
                {
                    return orcFemaleFirstNames[random.Next(orcFemaleFirstNames.Count)];
                }
            }
        }
        else if (race == "Tiefling")
        {
            if (gender == "M")
            {
                return tieflingMaleFirstNames[random.Next(tieflingMaleFirstNames.Count)];
            }
            else
            {
                return tieflingFemaleFirstNames[random.Next(tieflingFemaleFirstNames.Count)];
            }
        }
        else
        {
            if (gender == "M")
            {
                return "John";
            }
            else
            {
                return "Jane";
            }
        }
    }
}