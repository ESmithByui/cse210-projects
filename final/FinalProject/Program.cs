using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");

        PersonGenerator gen = new PersonGenerator();

        POI place1 = new CraftGlassmaker("Name of Place", gen.GenRandomPerson(), 4, gen);

        foreach (string line in place1.DisplayPOI())
        {
            Console.WriteLine(line);
        }
    }
}