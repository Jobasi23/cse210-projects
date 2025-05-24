public class Job
{
    private string _jobTitle;
    private string _company;
    private int _startYear;
    private int _endYear;

    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

    public void DisplayJobDetails()
    {
        Console.WriteLine($"Job Title: {_jobTitle}");
        Console.WriteLine($"Company: {_company}");
        Console.WriteLine($"Start Year: {_startYear}");
        Console.WriteLine($"End Year: {_endYear}");
    }
}