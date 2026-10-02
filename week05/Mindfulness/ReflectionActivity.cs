using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will encourage you to recognize the power you have and how you can use it in other aspects of your life.",
        0)
    {
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);

        return _questions[index];
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(GetRandomPrompt());

        Console.WriteLine();
        Console.WriteLine("When you are ready, begin reflecting...");
        ShowSpinner(3);

        int elapsedTime = 0;

        while (elapsedTime < GetDuration())
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomQuestion());

            ShowSpinner(10);
            elapsedTime += 10;
        }

        DisplayEndingMessage();
    }
}