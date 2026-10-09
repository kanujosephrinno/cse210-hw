using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("The Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int pointsEarned = _goals[goalIndex].RecordEvent();

        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
       
    }

    public void DisplayScore()
{
    Console.WriteLine($"Your total score is {_score} points.");

    if (_score >= 500)
    {
        Console.WriteLine(
            "Quest Rank: Quest Master! Your dedication is inspiring!");
    }
    else if (_score >= 250)
    {
        Console.WriteLine(
            "Quest Rank: Quest Champion! Keep building good habits!");
    }
    else if (_score >= 100)
    {
        Console.WriteLine(
            "Quest Rank: Quest Beginner! Every great journey starts with a step!");
    }
    else
    {
        Console.WriteLine(
            "Quest Rank: New Adventurer! Start small and keep going!");
    }
}
    public void SaveGoals()
{
    List<string> lines = new List<string>();

    // Save the total score first.
    lines.Add(_score.ToString());

    // Save each goal on its own line.
    foreach (Goal goal in _goals)
    {
        lines.Add(goal.GetSaveString());
    }

    File.WriteAllLines("goals.txt", lines);

    Console.WriteLine("Goals saved successfully!");
}
public void LoadGoals()
{
    if (!File.Exists("goals.txt"))
    {
        Console.WriteLine("No saved goals file was found.");
        return;
    }

    string[] lines = File.ReadAllLines("goals.txt");

    if (lines.Length == 0)
    {
        Console.WriteLine("The saved file is empty.");
        return;
    }

    if (!int.TryParse(lines[0], out int savedScore))
    {
        Console.WriteLine("The saved score is invalid.");
        return;
    }

    List<Goal> loadedGoals = new List<Goal>();

    for (int i = 1; i < lines.Length; i++)
    {
        string[] parts = lines[i].Split('|');

        if (parts.Length < 4)
        {
            Console.WriteLine($"Skipping invalid goal on line {i + 1}.");
            continue;
        }

        if (!int.TryParse(parts[3], out int points) || points <= 0)
        {
            Console.WriteLine($"Skipping goal with invalid points on line {i + 1}.");
            continue;
        }

        switch (parts[0])
        {
           case "SimpleGoal":
    if (parts.Length >= 5 &&
        bool.TryParse(parts[4], out bool isComplete))
    {
        SimpleGoal simple = new SimpleGoal(
            parts[1], parts[2], points);

        simple.SetComplete(isComplete);
        loadedGoals.Add(simple);
    }
    else
    {
        Console.WriteLine(
            $"Invalid Simple Goal on line {i + 1}.");
    }
    break;

            case "EternalGoal":
                EternalGoal eternal = new EternalGoal(
                    parts[1], parts[2], points);

                loadedGoals.Add(eternal);
                break;

            case "ChecklistGoal":
                if (parts.Length >= 7 &&
                    int.TryParse(parts[4], out int completed) &&
                    int.TryParse(parts[5], out int target) &&
                    int.TryParse(parts[6], out int bonus) &&
                    target > 0 && completed >= 0 &&
                    completed <= target && bonus >= 0)
                {
                    ChecklistGoal checklist = new ChecklistGoal(
                        parts[1], parts[2], points, target, bonus);

                    checklist.SetAmountCompleted(completed);
                    loadedGoals.Add(checklist);
                }
                break;

            default:
                Console.WriteLine($"Unknown goal type on line {i + 1}.");
                break;
        }
    }

    _goals.Clear();
    _goals.AddRange(loadedGoals);
    _score = savedScore;

    Console.WriteLine("Goals loaded successfully!");
    DisplayGoals();
    DisplayScore();
}
}