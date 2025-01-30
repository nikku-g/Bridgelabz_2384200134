using System;

class EuclideanDistance
{
    // Method to find the Euclidean distance between two points
    static double CalculateEuclideanDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    // Method to find the equation of the line in the form y = mx + b
    static double[] FindLineEquation(double x1, double y1, double x2, double y2)
    {
        // Calculate the slope (m)
        double m = (y2 - y1) / (x2 - x1);

        // Calculate the y-intercept (b)
        double b = y1 - m * x1;

        // Return the slope and y-intercept as an array
        return new double[] { m, b };
    }

    static void Main()
    {
        // Taking input for the two points (x1, y1) and (x2, y2)
        Console.WriteLine("Enter the coordinates of the first point (x1, y1):");
        Console.Write("x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the coordinates of the second point (x2, y2):");
        Console.Write("x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        // Calculate the Euclidean distance
        double distance = CalculateEuclideanDistance(x1, y1, x2, y2);
        Console.WriteLine("\nThe Euclidean distance between the two points is: " + distance);

        // Calculate the equation of the line
        double[] lineEquation = FindLineEquation(x1, y1, x2, y2);
        double slope = lineEquation[0];
        double intercept = lineEquation[1];

        // Display the equation of the line
        Console.WriteLine("\nThe equation of the line is: y = " + slope + "x + " + intercept);
    }
}
