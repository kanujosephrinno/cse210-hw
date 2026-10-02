using System;

class Program
{
    static void Main(string[] args)
    {
        int completedActivities = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program.");
                Console.WriteLine($"Activities completed this session: {completedActivities}");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}

/*
 * Creativity and exceeding requirements:
 * Added a session activity counter that keeps track of how many
 * mindfulness activities the user completes during the current session.
 */