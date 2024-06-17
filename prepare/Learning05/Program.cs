using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        List<Shape> shapes = new List<Shape>
        {
            new Square("red", 5),
            new Rectangle("blue", 3, 4.5),
            new Circle("green", 10)
        };

        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} | {shape.GetArea()}");
        }
    }
}