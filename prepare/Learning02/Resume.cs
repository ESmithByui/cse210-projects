using System;

public class Resume()
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {this._name}\nJob:");

        foreach(Job job in this._jobs)
        {
            job.Display();
        }
    }

}