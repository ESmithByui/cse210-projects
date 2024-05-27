using System;
using System.IO.Enumeration;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Security.Authentication;
using System.Text.RegularExpressions;


public class Library
{
    private List<Scripture> scriptures = new List<Scripture>();

    private string fileName;

    public Library()
    {
        fileName = "";
    }

    public Library(string fileName)
    {
        this.fileName = fileName;

        LoadFile();
    }

    public void SetFile(string fileName)
    {
        this.fileName = fileName;
    }

    private void LoadFile()
    {
        using (var reader = new StreamReader(fileName))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                string[] lineArray = line.Split("<>");

                if (lineArray.Length > 2)
                {
                    List<string> verses = new List<string>();
                    for(int i = 1; i < lineArray.Length; i++)
                    {
                        verses.Add(lineArray[i]);
                    }
                    scriptures.Add(new Scripture(lineArray[0],verses));
                }
                else if (lineArray.Length == 2)
                {
                    scriptures.Add(new Scripture(lineArray[0], lineArray[1]));
                }

            }
        }
    }

    public void DisplayReferences()
    {
        int i = 0;
        foreach(Scripture scripture in scriptures)
        {
            i++;
            Console.WriteLine($"{i}. {scripture.GetReference()}");
        }
    }

    public string GetSpecificReference(int number)
    {
        return scriptures[number].GetReference();
    }

    public void ChooseScripture(string userInput, bool memoryType, int modifier)
    {
        bool match = false;
        foreach(Scripture scripture in scriptures)
        {
            if (userInput.ToLower() == scripture.GetReference().ToLower())
            {
                if(memoryType)
                {
                    scripture.MemorizeScripturePassage(modifier);
                }
                else
                {
                    scripture.MemorizeScriptureVerse(modifier);
                }
                match = true;
                Console.Clear();
            }
        }
        if (!match)
        {
            Console.WriteLine("There is no matching scripture. Returning to main menu.");
            Console.ReadLine();
        }
    }
}