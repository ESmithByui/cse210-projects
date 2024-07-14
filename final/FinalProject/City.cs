using System;

public class City
{
    private string name;
    private Person leader;
    private int population;
    private int poiCount;
    private bool guilds;
    private int magicLvl;
    private List<POI> pointsOfInterest;
    private PersonGenerator personGen;
    private BuildingNameGen buildingGen = new BuildingNameGen();

    public City(string name, int tier, PersonGenerator personGen, bool guilds, int magicLvl)
    {

    }

    public City(string name, int tier, PersonGenerator personGen, bool guilds, int magicLvl, Person ruler)
    {

    }

    public int GetPopulation()
    {
        return population;
    }

    public string GetName()
    {
        return name;
    }

    public void DisplayCity()
    {

    }

    public List<string> FormatCity()
    {

    }

    public void AddPOI()
    {
        
    }

}