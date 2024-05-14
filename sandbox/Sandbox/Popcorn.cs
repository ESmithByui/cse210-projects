using System;

public class Popcorn()
{
    public List<Seasoning> seasonings = new List<Seasoning>();

    public void Display()
    {
        foreach (Seasoning seasoning in seasonings)
        {
            seasoning.Display();
        }
    }
}