// Creativity: I added a personal challenge prompt to encourage reflection on how i overcome difficulties.

Journal journal = new Journal();
PromptGenerator promptGenerator = new PromptGenerator();


Console.WriteLine("Welcome to the Journal Program!");
while (true)
{
Console.WriteLine("Please select one of the following choices:");

Console.WriteLine("1. Write a new entry");
Console.WriteLine("2. Display the journal");
Console.WriteLine("3. Save the journal to a file");
Console.WriteLine("4. Load the journal from a file");
Console.WriteLine("5. Quit");

Console.Write("What is your choice? ");
string choice = Console.ReadLine();
if (choice == "1")
{
    Console.WriteLine("Writing a new journal entry...");
    string prompt = promptGenerator.GetRandomPrompt();
    Console.WriteLine($"Prompt: {prompt}");
    Console.Write(" your response: ");
    string response = Console.ReadLine();
    string date = DateTime.Now.ToString("yyyy-MM-dd");
Entry entry = new Entry(date, prompt, response);
journal.AddEntry(entry);
}
if (choice == "2")
{
    journal.Display();
}
if (choice == "3")
{
    journal.SaveToFile("journal.txt");
    Console.WriteLine("Journal saved successfully!");
}
if (choice == "4")
{
    journal.LoadFromFile("journal.txt");
    Console.WriteLine("Journal loaded successfully!");
}

    if (choice == "5")
{
        break;
}
}