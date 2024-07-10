using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");

        PersonGenerator gen = new PersonGenerator();

        POI place1 = new CraftGlassmaker("Berry Circus", gen.GenRandomPerson(), 4, gen);

        foreach (string line in place1.DisplayPOI())
        {
            Console.WriteLine(line);
        }

        place1 = new EntMuseum("Smithsonian", gen.GenRandomPerson(), 4, gen);

        foreach (string line in place1.DisplayPOI())
        {
            Console.WriteLine(line);
        }

        place1 = new EntPark("Porter Park", gen.GenRandomPerson(), 4);

        foreach (string line in place1.DisplayPOI())
        {
            Console.WriteLine(line);
        }

        place1 = new EntTheater("Comedy Theater", gen.GenRandomPerson(), 4, gen);

        foreach (string line in place1.DisplayPOI())
        {
            Console.WriteLine(line);
        }
    }
}