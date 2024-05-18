using System;

public class Journal
{
    List<Entry> entries = new List<Entry>();

    PromptGenerator promptGen = new PromptGenerator();

    public void Write()
    {
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        
        string prompt = "";

        if(entries.Count == 0)
        {
            prompt = promptGen.getPrompt(prompt);
        }
        else
        {
            prompt = promptGen.getPrompt(entries.Last().prompt);
        }
        
        Console.WriteLine(prompt);
        string userInput = Console.ReadLine();

        entries.Add(new Entry(currentDate, prompt, userInput));

        Console.WriteLine($"Entry created successfully");

    }

    public void Display()
    {
        Console.WriteLine("Entries:");
        if(entries.Count() == 0)
        {
            Console.WriteLine("There is nothing to display.");
        }

        else
        {
            foreach(Entry entry in entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }
    }

    public void Save()
    {
        Console.WriteLine("Enter what you'd like the file to be called\n(.csv is the recommended file type):");

        string filePath = Console.ReadLine();

        using(StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Date,Prompt,Text");

            foreach(Entry entry in entries)
            {
                writer.WriteLine($"\"{entry.date}\",\"{entry.prompt}\",\"{entry.text.Replace("\"", "\"\"")}\"");
            }
        }

        Console.WriteLine($"{filePath} saved successfully");
    }

    public void Load()
    {
        Console.WriteLine("Enter the file you'd like to load:");

        string filePath = Console.ReadLine();

        entries = new List<Entry>();

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                List<string> parsed = ParseCsvLine(line);

                entries.Add(new Entry(parsed[0], parsed[1], parsed[2].Replace("\"\"", "\"")));
            }
        }

        Console.WriteLine($"{filePath} loaded successfully");
    }

    List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        int startIndex = 0;

        for(int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(line.Substring(startIndex, i - startIndex));

                startIndex = i + 1;
            }
        }

        fields.Add(line.Substring(startIndex));

        List<string> parsedFields = new List<string>();

        foreach(string field in fields)
        {
            parsedFields.Add(field.Substring(1, field.Length - 2));
        }

        return parsedFields;
    }


}