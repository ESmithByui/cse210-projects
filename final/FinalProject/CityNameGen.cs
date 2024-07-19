using System;

public class CityNameGen
{
    private Random random = new Random();
    private List<string> namingFiles = new List<string>{
        "otherNames/city_adjetives.txt",
        "otherNames/city_names.txt"
    };
    private List<string> adjetives = new List<string>();
    private List<string> names = new List<string>();
    private List<string> usedNames = new List<string>();

    public CityNameGen()
    {
        LoadFile(namingFiles[0], adjetives);
        LoadFile(namingFiles[1], names);
    }

    private void LoadFile(string fileName, List<string> returnList)
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

}