using System.Collections.Generic;

class Scripture
{
    Reference reference;
    List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        string[] wordList = text.Split(' ');

        foreach (string word in wordList)
        {
            words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string display = reference.GetDisplayText() + "\n";

        foreach (Word word in words)
        {
            display += word.GetDisplayText() + " ";
        }

        return display.Trim();

    }
    
    public void HideRandomWords()
{
    Random random = new Random();

    for (int i = 0; i < 3; i++)
    {
        int index = random.Next(words.Count);
        words[index].Hide();
    }
}

public bool IsCompletelyHidden()
{
    foreach (Word word in words)
    {
        if (!word.IsHidden())
        {
            return false;
        }
    }

    return true;
}
}