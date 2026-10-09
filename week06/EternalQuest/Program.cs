using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"Welcome to Your Eternal Quest!");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    RecordGoal(manager);
                    break;
                       // Creative enhancement: DisplayScore shows a Quest Rank
                // based on the user's total points. The ranks reward progress
                // and encourage users to continue building positive habits.
                case "4":
                    manager.DisplayScore();
                    break;
                

                 case "5":
                   manager.SaveGoals();
                    break;

                 case "6":
                   manager.LoadGoals();
                    break;

                 case "7":
                    running = false;
                    Console.WriteLine("Keep going on your Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Please choose a number from 1 to 7.");
                    break;
            }
        }
    }

    

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Choose the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");

        string type = Console.ReadLine() ?? "";

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Enter the points for this goal: ");

        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("Please enter a valid positive number of points.");
            return;
        }

        Goal goal;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                Console.Write("How many times must you complete this goal? ");

                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("Please enter a valid positive target.");
                    return;
                }

                Console.Write("How many bonus points will you earn? ");

                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("Please enter a valid non-negative bonus.");
                    return;
                }

                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordGoal(GoalManager manager)
    {
        manager.DisplayGoals();

        Console.Write("Which goal number did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber <= 0)
        {
            Console.WriteLine("Please enter a valid goal number.");
            return;
        }

        manager.RecordEvent(goalNumber - 1);
        manager.DisplayScore(); // Display the updated score after recording the event
    }
}