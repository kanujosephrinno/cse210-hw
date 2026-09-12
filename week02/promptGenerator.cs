using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What is something you are grateful for today?",
        "Who made you smile today and why?",
        "What challenge did I face today and how did I overcome it?",
        "What is something new I learned today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}