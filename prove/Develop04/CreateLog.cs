using System;

public class CreateLog
{
    private string fileName;

    public CreateLog(string timeInitialized)
    {
        fileName = $"{timeInitialized}.txt";
        using(StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"~~~ {timeInitialized} Mindfulness Program ~~~");
            writer.WriteLine($"> {timeInitialized} ~ Program successfully initialized.");
        }
    }

    public void WriteLog(string data)
    {
        using(StreamWriter writer = new StreamWriter(fileName, true))
        {
            string current = DateTime.Now.ToString("MM-dd-yyyy_H-mm-ss");
            writer.WriteLine($"> {current} ~ {data}");
        }
    }
}