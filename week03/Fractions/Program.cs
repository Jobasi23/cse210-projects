using System;

class Program
{
    static void Main()
    {
        // Create fractions using all three constructors
        Fraction f1 = new Fraction();           // 1/1
        Fraction f2 = new Fraction(5);          // 5/1
        Fraction f3 = new Fraction(3, 4);       // 3/4
        Fraction f4 = new Fraction(1, 3);       // 1/3

        // Display initial values
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test setters and getters
        f1.SetTop(6);
        f1.SetBottom(7);
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
    }
    
    public class Fraction
    {
        private int _top;
        private int _bottom;
    
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }
    
        public Fraction(int wholeNumber)
        {
            _top = wholeNumber;
            _bottom = 1;
        }
    
        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }
    
        public void SetTop(int top)
        {
            _top = top;
        }
    
        public void SetBottom(int bottom)
        {
            _bottom = bottom;
        }
    
        public int GetTop()
        {
            return _top;
        }
    
        public int GetBottom()
        {
            return _bottom;
        }
    
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }
    
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
}