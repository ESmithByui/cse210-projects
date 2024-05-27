using System;
using System.Net;
using System.Security;

public class Verse
{
    private List<Word> words = new List<Word>();

    private int verseNumber;

    private int wordCount;

    private Random random;

    public Verse(int number, string text)
    {
        verseNumber = number;

        string[] textArray = text.Split(" ");

        foreach(string word in textArray)
        {
            words.Add(new Word(word));
        }

        wordCount = words.Count;

        random = new Random();
    }

    public void HideWords(int modifier)
    {
        for(int i = 0; i < modifier; i++)
        {
            if(CheckVisible())
            {
                bool notChanged = true;
                int rng = 0;
                do
                {
                    rng = random.Next(wordCount);
                    if(!words[rng].GetHidden())
                    {
                        words[rng].Hide();
                        notChanged = false;
                    }
                }while(notChanged);
            }
        }
    }

    public void UnHideAll()
    {
        foreach(Word word in words)
        {
            word.Show();
        }
    }

    public void DisplayVerse()
    {   
        Console.Write(verseNumber);
        foreach(Word word in words)
        {
            Console.Write(" ");
            word.DisplayWord();
        }
        Console.WriteLine();
    }

    public bool CheckVisible()
    {
        bool visible = false;
        foreach(Word word in words)
        {
            if(!word.GetHidden())
            {
                visible = true;
            }
        }

        return visible;
    }
}