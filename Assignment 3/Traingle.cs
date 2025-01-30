using System;

class Traingle
{
    // Method to calculate the slope between two points (x1, y1) and (x2, y2)
    static double CalculateSlope(double x1, double y1, double x2, double y2)
    {
        // Slope formula: (y2 - y1) / (x2 - x1)
        return (y2 - y1) / (x2 - x1);
    }

    // Method to check if the points are collinear using the Slope Formula
    static bool ArePointsCollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        // Calculate the slopes of AB, BC, and AC
        double slopeAB = CalculateSlope(x1, y1, x2, y2);
        double slopeBC = CalculateSlope(x2, y2, x3, y3);
        double slopeAC = CalculateSlope(x1, y1, x3, y3);

        // Points are collinear if the slopes are equal
        return (slopeAB == slopeBC && slopeBC == slopeAC);
    }

    // Method to check if the points are collinear using the Area of Triangle Formula
    static bool ArePointsCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        // Area formula: 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2))
        double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));

        // Points are collinear if the area is 0
        return area == 0;
    }

    static void Main()
    {
        // Taking input for 3 points (x1, y1), (x2, y2), and (x3, y3)
        Console.WriteLine("Enter the coordinates of point A (x1, y1):");
        Console.Write("x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the coordinates of point B (x2, y2):");
        Console.Write("x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the coordinates of point C (x3, y3):");
        Console.Write("x3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());
        Console.Write("y3: ");
        double y3 = Convert.ToDouble(Console.ReadLine());

        // Check collinearity using the Slope Method
        bool collinearBySlope = ArePointsCollinearBySlope(x1, y1, x2, y2, x3, y3);
        // Check collinearity using the Area of Triangle Method
        bool collinearByArea = ArePointsCollinearByArea(x1, y1, x2, y2, x3, y3);

        // Output the results
        if (collinearBySlope)
        {
            Console.WriteLine("The points are collinear by slope method.");
        }
        else
        {
            Console.WriteLine("The points are NOT collinear by slope method.");
        }

        if (collinearByArea)
        {
            Console.WriteLine("The points are collinear by area method.");
        }
        else
        {
            Console.WriteLine("The points are NOT collinear by area method.");
        }
    }
}
