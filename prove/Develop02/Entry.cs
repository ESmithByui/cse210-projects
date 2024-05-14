using System;

public class Entry
{
    public string date { get; set; }
    public string prompt { get; set; }
    public string text { get; set; }

    public Entry(string currentDate, string givenPrompt, string userText)
    {
        date = currentDate;
        prompt = givenPrompt;
        text = userText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {date} - Prompt: {prompt}");
        Console.WriteLine(text);
    }
}