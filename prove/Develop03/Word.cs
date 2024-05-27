using System;

public class Word
{
    private string word;

    private bool isHidden;

    public Word(string word)
    {
        this.word = word;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public void Show()
    {
        isHidden = false;
    }

    public bool GetHidden()
    {
        return isHidden;
    }

    public void DisplayWord()
    {
        if(isHidden)
        {
            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if(Char.IsLetter(c))
                {
                    Console.Write("_");
                }
                
                else
                {
                    Console.Write(c);
                }
            }
        }
        else
        {
            Console.Write(word);
        }
    }
}