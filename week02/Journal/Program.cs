using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }
    public string Mood { get; set; } // Additional info

    public JournalEntry() { }

    public JournalEntry(DateTime date, string prompt, string content, string mood)
    {
        Date = date;
        Prompt = prompt;
        Content = content;
        Mood = mood;
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private string[] prompts = new[]
    {
        "What are you grateful for today?",
        "Describe a challenge you faced today.",
        "What made you smile today?",
        "What did you learn today?",
        "How are you feeling right now?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your entry: ");
        string content = Console.ReadLine();
        Console.Write("How is your mood? (e.g., Happy, Sad, Excited): ");
        string mood = Console.ReadLine();
        entries.Add(new JournalEntry(DateTime.Now, prompt, content, mood));
        Console.WriteLine("Entry added!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        foreach (var entry in entries)
        {
            Console.WriteLine($"\nDate: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Mood: {entry.Mood}");
            Console.WriteLine($"Entry: {entry.Content}");
        }
    }

    public void SaveToFile(string filename)
    {
        if (filename.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.WriteLine("Journal saved as JSON.");
        }
        else
        {
            using (var writer = new StreamWriter(filename, false, Encoding.UTF8))
            {
                writer.WriteLine("Date,Prompt,Mood,Content");
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{CsvEscape(entry.Date.ToString())},{CsvEscape(entry.Prompt)},{CsvEscape(entry.Mood)},{CsvEscape(entry.Content)}");
                }
            }
            Console.WriteLine("Journal saved as CSV.");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        if (filename.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<JournalEntry>>(json) ?? new List<JournalEntry>();
            Console.WriteLine("Journal loaded from JSON.");
        }
        else
        {
            var lines = File.ReadAllLines(filename);
            entries.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                var fields = CsvParseLine(lines[i]);
                if (fields.Count >= 4)
                {
                    if (DateTime.TryParse(fields[0], out DateTime date))
                    {
                        entries.Add(new JournalEntry(date, fields[1], fields[3], fields[2]));
                    }
                }
            }
            Console.WriteLine("Journal loaded from CSV.");
        }

        // Recall: Display what was loaded
        Console.WriteLine("\nEntries recalled from file:");
        DisplayEntries();
    }

    private string CsvEscape(string s)
    {
        if (s.Contains("\"") || s.Contains(",") || s.Contains("\n"))
        {
            s = s.Replace("\"", "\"\"");
            return $"\"{s}\"";
        }
        return s;
    }

    private List<string> CsvParseLine(string line)
    {
        var result = new List<string>();
        bool inQuotes = false;
        StringBuilder field = new StringBuilder();
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        field.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    field.Append(c);
                }
            }
            else
            {
                if (c == ',')
                {
                    result.Add(field.ToString());
                    field.Clear();
                }
                else if (c == '"')
                {
                    inQuotes = true;
                }
                else
                {
                    field.Append(c);
                }
            }
        }
        result.Add(field.ToString());
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file (.csv or .json)");
            Console.WriteLine("4. Load the journal from a file (.csv or .json)");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save (.csv or .json): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load (.csv or .json): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}