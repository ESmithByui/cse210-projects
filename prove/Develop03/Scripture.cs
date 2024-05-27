using System;
using System.Runtime.InteropServices;


public class Scripture
{
    private string reference;

    private List<Verse> verses = new List<Verse>();

    public Scripture(string reference, string text)
    {
        this.reference = reference;

        int verseNumber = ParseVerseNumber(reference);

        verses.Add(new Verse(verseNumber, text));
    }

    public Scripture(string reference, List<string> texts)
    {
        this.reference = reference;

        List<int> verseRange = ParseVerseRange(reference);

        for(int i = 0; i < texts.Count; i++)
        {
            verses.Add(new Verse(verseRange[i], texts[i]));
        }
    }

    public string GetReference()
    {
        return reference;
    }

    private int ParseVerseNumber(string reference)
    {
        int startIndex = 0;
        for(int i = 0; i < reference.Length; i++)
        {
            char c = reference[i];

            if (c == ':')
            {
                startIndex = i + 1;
            }
        }
        return int.Parse(reference.Substring(startIndex));
    }

    private List<int> ParseVerseRange(string reference)
    {
        int startIndex = 0;
        int verseStart = 0;
        int verseEnd = 0;
        bool isRange = false;
        List<int> range = new List<int>();

        for(int i = 0; i < reference.Length; i++)
        {
            char c = reference[i];

            if (c == ':')
            {
                startIndex = i + 1;
            }
            else if (c == '-')
            {
                verseStart = int.Parse(reference.Substring(startIndex, i - startIndex));
                isRange = true;
                startIndex = i + 1;
            }
            else if (c == ',' && !isRange)
            {
                range.Add(int.Parse(reference.Substring(startIndex, i - startIndex)));
                startIndex = i + 1;
            }
            else if (c == ',' && isRange)
            {
                verseEnd = int.Parse(reference.Substring(startIndex, i - startIndex));
                isRange = false;
                startIndex = i + 1;

                for(int v = verseStart; v <= verseEnd; v++)
                {
                    range.Add(v);
                }
            }
        }

        if(isRange)
        {
            verseEnd = int.Parse(reference.Substring(startIndex));
            isRange = false;
            for(int v = verseStart; v <= verseEnd; v++)
            {
                range.Add(v);
            }
        }
        else
        {
            range.Add(int.Parse(reference.Substring(startIndex)));
        }

        return range;
    }

    public void MemorizeScripturePassage(int modifier)
    {
        string userInput = "";
        bool visible = true;
        Console.Clear();
        Console.WriteLine(reference);
        Console.WriteLine();
        foreach(Verse verse in verses)
        {
            verse.UnHideAll();
            verse.DisplayVerse();
            Console.WriteLine();
        }
        Console.WriteLine("Press enter to continue or type quit to finish:");
        userInput = Console.ReadLine();

        while (userInput != "quit" && visible)
        {
            visible = false;
            Console.Clear();
            Console.WriteLine(reference);
            Console.WriteLine();
            foreach(Verse verse in verses)
            {
                verse.HideWords(modifier);
                verse.DisplayVerse();
                Console.WriteLine();

                if (verse.CheckVisible())
                {
                    visible = true;
                }
            }

            Console.WriteLine("Press enter to continue or type quit to finish:");
            userInput = Console.ReadLine();
        }

    }

    public void MemorizeScriptureVerse(int modifier)
    {
        string userInput = "";
        foreach(Verse verse in verses)
        {
            verse.UnHideAll();
            Console.Clear();
            Console.WriteLine(reference);
            Console.WriteLine();
            verse.DisplayVerse();
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type quit to finish:");
            userInput = Console.ReadLine();

            while (userInput != "quit" && verse.CheckVisible())
            {
                Console.Clear();
                Console.WriteLine(reference);
                Console.WriteLine();
                verse.HideWords(modifier);
                verse.DisplayVerse();
                Console.WriteLine();

                Console.WriteLine("Press enter to continue or type quit to finish:");
                userInput = Console.ReadLine();
            }
            if (userInput == "quit")
            {
                return;
            }
        }
    }
}