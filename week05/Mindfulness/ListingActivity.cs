using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
        0)
    {
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
    public void Run()
{
    DisplayStartingMessage();

    Console.WriteLine();
    Console.WriteLine("List as many responses as you can to the following prompt:");
    Console.WriteLine(GetRandomPrompt());

    Console.WriteLine();
    Console.WriteLine("You may begin in:");
    ShowSpinner(5);

    int count = 0;
    DateTime startTime = DateTime.Now;

    while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
    {
        Console.Write("> ");
        string answer = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(answer))
        {
            count++;
        }
    }

    Console.WriteLine();
    Console.WriteLine($"You listed {count} items.");

    DisplayEndingMessage();
}
}