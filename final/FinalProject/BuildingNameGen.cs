using System;

public class BuildingNameGen
{
    private Random random = new Random();
    private List<string> namingFiles = new List<string>{
        "otherNames/building_adjetives.txt",
        "otherNames/building_names.txt"
    };
    private List<string> adjetives = new List<string>();
    private List<string> names = new List<string>();
    private List<string> usedNames = new List<string>();

    public BuildingNameGen()
    {
        LoadFile(namingFiles[0], adjetives);
        LoadFile(namingFiles[1], names);
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

    public string GetRandomName()
    {
        string newName = "";

        do
        {
            newName = $"{adjetives[random.Next(adjetives.Count)]} {names[random.Next(names.Count)]}";
        }while (usedNames.Contains(newName));

        usedNames.Add(newName);
        return newName;
    }

    public string GetNamedName(string name)
    {
        string newName = "";

        do
        {
            newName = $"{adjetives[random.Next(adjetives.Count)]} {name}";
        }while (usedNames.Contains(newName));

        usedNames.Add(newName);
        return newName;
    }

    public void AddCustomName(string usedName)
    {
        usedNames.Add(usedName);
    }

    public bool CheckUsed(string newName)
    {
        if (usedNames.Contains(newName))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}