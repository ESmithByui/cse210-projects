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
            "If I had one thing I could do over today, what would it be?",
            "What are three things you're grateful for today, and why?",
            "Describe a recent challenge you faced. How did you overcome it, or how are you working through it?",
            "Reflect on a moment from your past that taught you something important about yourself or life.",
            "What are your top three priorities for the week ahead, and how do you plan to accomplish them?",
            "Write about a person who has had a significant impact on your life, and why they are important to you.",
            "Describe a place that holds special meaning for you. What memories or emotions does it evoke?",
            "What is one fear you have, and what steps can you take to confront or overcome it?",
            "Reflect on a recent success or achievement. What did you learn from the experience?",
            "Write about a book, movie, or piece of art that has influenced you and why it resonated with you.",
            "What are some habits or routines you would like to cultivate or change in your life, and why?"
        };

        rng = new Random();
    }

    public string getPrompt(string lastPrompt)
    {
        
        int index = rng.Next(prompts.Count);
        
        while (prompts[index] == lastPrompt)
        {
            index = rng.Next(prompts.Count);
        }

        return prompts[index];
    }
}