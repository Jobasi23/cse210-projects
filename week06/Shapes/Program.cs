using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("This is the Shapes Project.");

        // Create a list of shapes using collection initializer
        var shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Circle("Green", 3)
        };

        // Iterate and display color and area
        foreach (var shape in shapes)
        {
            Console.WriteLine($"The {shape.Color} shape has an area of {shape.GetArea()}.");
        }
    }
} 