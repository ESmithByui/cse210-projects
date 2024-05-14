using System;

public class Seasoning()
{
    public string title = "";
    public int quantity = 0;

    public void Display()
    {
        Console.WriteLine($"{this.title} has {this.quantity} in stock.");
    }
}