using System;

class PromptGenerator
{
    List<string> prompts;
    Random rng;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        rng = new Random();
    }

    public string getPrompt()
    {
        int index = rng.Next(prompts.Count);
        return prompts[index];
    }
}