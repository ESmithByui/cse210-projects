using System;

public class CountryNameGen
{
    private Random random = new Random();
    private List<string> namingFiles = new List<string>{
        "otherNames/country_adjetives.txt",
        "otherNames/country_names.txt"
    };
    private List<string> adjetives = new List<string>();
    private List<string> names = new List<string>();

    public CountryNameGen()
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
        return $"{adjetives[random.Next(adjetives.Count)]} {names[random.Next(names.Count)]}";
    }

}