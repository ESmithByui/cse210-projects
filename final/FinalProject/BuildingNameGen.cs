using System;

public class BuildingNameGen
{
    private Random random = new Random();
    private List<string> namingFiles = new List<string>{
        "otherNames/adjetives.txt",
        "otherNames/names.txt"
    };
    private List<string> adjetives = new List<string>();
    private List<string> names = new List<string>();
    private List<string> usedNames = new List<string>();

    public BuildingNameGen()
    {

    }

    public string GetRandomName()
    {
        
    }

    public string GetNamedName(string name)
    {

    }

    public void AddCustomName(string usedName)
    {

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