using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
        0)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsedTime = 0;

        while (elapsedTime < GetDuration())
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountdown(4);

            elapsedTime += 4;

            if (elapsedTime >= GetDuration())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountdown(4);

            elapsedTime += 4;
        }

        DisplayEndingMessage();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }
}