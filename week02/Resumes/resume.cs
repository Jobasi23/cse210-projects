using System.Collections.Generic;

public class Resume
{
    public string Name;
    public List<Job> Jobs = new List<Job>();

    public Resume()
    {
        Jobs.Add(new Job { Title = "Software Engineer" });
        Jobs.Add(new Job { Title = "Project Manager" });
    }

    public void Display()
    {
        System.Console.WriteLine($"Name: {Name}");
        foreach (var job in Jobs)
        {
            job.Display();
        }
    }
}

public class Job
{
    public string Title;

    public void Display()
    {
        System.Console.WriteLine($"Job Title: {Title}");
    }
}

class Program
{
    static void Main()
    {
        Resume myResume = new Resume();
        myResume.Name = "John Doe";
        myResume.Display();
    }
}
