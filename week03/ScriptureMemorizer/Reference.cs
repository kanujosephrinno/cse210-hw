class Reference
{
    string book;
    int chapter;
    int verse;
    int endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
        this.endVerse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
        this.endVerse = endVerse;
    }
    public string GetDisplayText()
    {
        if (verse == endVerse)
        {
            return $"{book} {chapter}:{verse}";
        }
        else
        {
            return $"{book} {chapter}:{verse}-{endVerse}";
        }
    }
}