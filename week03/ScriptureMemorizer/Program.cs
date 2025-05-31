using System;

class Program
{
    static void Main()
    {
        // Example scripture: Proverbs 3:5-6
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
                break;

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will now end.");
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 random words each time
        }
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (_verseEnd.HasValue)
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        else
            return $"{_book} {_chapter}:{_verseStart}";
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        var notHidden = _words.Where(w => !w.IsHidden).ToList();
        if (notHidden.Count == 0)
            return;

        for (int i = 0; i < count; i++)
        {
            var candidates = _words.Where(w => !w.IsHidden).ToList();
            if (candidates.Count == 0)
                break;
            int idx = _random.Next(candidates.Count);
            candidates[idx].Hide();
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public bool IsHidden => _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
            return _text;

        // Preserve punctuation at the end
        string word = _text;
        string trailing = "";
        if (char.IsPunctuation(word.Last()))
        {
            trailing = word.Last().ToString();
            word = word.Substring(0, word.Length - 1);
        }
        return new string('_', word.Length) + trailing;
    }
}
