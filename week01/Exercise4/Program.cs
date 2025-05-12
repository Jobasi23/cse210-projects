using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("  Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"  The sum is: {sum}");
            Console.WriteLine($"  The average is: {average}");
            Console.WriteLine($"  The largest number is: {max}");

            
            int? smallestPositive = numbers.Where(n => n > 0).OrderBy(n => n).FirstOrDefault();
            if (smallestPositive.HasValue)
            {
                Console.WriteLine($"  The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("  No positive numbers were entered.");
            }

        
            numbers.Sort();
            Console.WriteLine("  The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine($"    {number}");
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}