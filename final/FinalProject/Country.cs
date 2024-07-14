using System;

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
    
    public Country(string name, int tier, bool guilds, int magicLvl)
    {

    }

    public Country(string name, int tier, bool guilds, int magicLvl, int totalCityCount)
    {

    }

    public List<string> FormatCountry()
    {

    }

    public void AddCity()
    {
        
    }

}