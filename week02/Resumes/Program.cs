class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        System.Console.WriteLine($"Job Title: {_jobTitle}, Company: {_company}, Start Year: {_startYear}, End Year: {_endYear}");
    }
}

class Program
{
    static void Main()
    {
        // Create the first job instance
        Job job1 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Microsoft",
            _startYear = 2015,
            _endYear = 2020
        };

        // Call the Display method for the first job
        job1.Display();

        // Create the second job instance
        Job job2 = new Job
        {
            _jobTitle = "Product Manager",
            _company = "Apple",
            _startYear = 2021,
            _endYear = 2023
        };

        // Call the Display method for the second job
        job2.Display();
    }
// Create a new instance of the Resume class
Resume myResume = new Resume();
