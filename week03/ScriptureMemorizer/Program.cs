//Creativity: I added a library of three scriptures and randomly
// select one each time the program starts, giving the user a different 
// scripture to practice memorizing.
using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Reference reference = new Reference("John", 3, 16);

        Scripture scripture = new Scripture(
            reference,
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
        );
        Scripture scripture2 = new Scripture(
    new Reference("Proverbs", 3, 5, 6),
    "Trust in the Lord with all thine heart and lean not unto thine own understanding"
);

Scripture scripture3 = new Scripture(
    new Reference("Philippians", 4, 13),
    "I can do all things through Christ which strengtheneth me"
);
int choice = random.Next(3);
if (choice == 1)
{
    scripture = scripture2;
}
else if (choice == 2)
{
    scripture = scripture3;
}

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}