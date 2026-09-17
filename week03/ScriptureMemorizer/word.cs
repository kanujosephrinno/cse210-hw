class Word
{
    string text;
    bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public string GetDisplayText()
    {
        if (isHidden)
        {
            return new string('_', text.Length);
        }
        else
        {
            return text;
        }
    }

    public bool IsHidden()
    {
        return isHidden;
    }
}