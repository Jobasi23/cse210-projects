abstract class Goal(string name, string description, int points)
{
    public string Name { get; protected set; } = name;
    public string Description { get; protected set; } = description;
    public int Points { get; protected set; } = points;
    public bool IsComplete { get; protected set; } = false;

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();

    // Ask the user for the necessary information to create a goal of the given type
    public static Goal CreateGoalFromUserInput()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                return new SimpleGoal(name, description, points);
            case "2":
                return new EternalGoal(name, description, points);
            case "3":
                Console.Write("Enter number of times to complete for a bonus: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                return new ChecklistGoal(name, description, points, targetCount, bonus);
            default:
                Console.WriteLine("Invalid choice.");
                return null;
        }
    }

    public static Goal Deserialize()
    {
        // Implement deserialization logic for each goal type
        // (left as an exercise)
        return null;
    }
}

// Placeholder implementations for missing goal types
class SimpleGoal(string name, string description, int points) : Goal(name, description, points)
{
    public override int RecordEvent() => 0;
    public override string GetStatus() => "";
    public override string Serialize() => "";
}

class EternalGoal(string name, string description, int points) : Goal(name, description, points)
{
    public override int RecordEvent() => 0;
    public override string GetStatus() => "";
    public override string Serialize() => "";
}

class ChecklistGoal(string name, string description, int points, int targetCount, int bonus) : Goal(name, description, points)
{
    public int TargetCount { get; } = targetCount;
    public int Bonus { get; } = bonus;
    public override int RecordEvent() => 0;
    public override string GetStatus() => "";
    public override string Serialize() => "";
}

// Entry point for the program
class Program
{
    static void Main()
    {
        Console.WriteLine("Eternal Quest program started.");
        // You can add code here to test your classes if needed
    }
}
