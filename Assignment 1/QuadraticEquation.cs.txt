using System;

public class Quadratic
{
    // Method to find the roots of a quadratic equation
    public double[] FindRoots(double a, double b, double c)
    {
        double delta = Math.Pow(b, 2) - 4 * a * c; // Calculate delta (discriminant)

        if (delta > 0)
        {
            // Two distinct real roots
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return new double[] { root1, root2 };
        }
        else if (delta == 0)
        {
            // One real root (repeated)
            double root = -b / (2 * a);
            return new double[] { root };
        }
        else
        {
            // No real roots
            return new double[0];
        }
    }
}

class QuadraticEquation
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the coefficients of the quadratic equation (ax^2 + bx + c):");

        // Input coefficients a, b, c
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());
        
        // Validate 'a' to ensure it is not zero
        while (a == 0)
        {
            Console.WriteLine("'a' cannot be zero for a quadratic equation. Please enter a valid value.");
            Console.Write("a: ");
            a = double.Parse(Console.ReadLine());
        }

        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());

        // Create an instance of the Quadratic class
        Quadratic quadratic = new Quadratic();

        // Find the roots
        double[] roots = quadratic.FindRoots(a, b, c);

        // Display the results
        if (roots.Length == 2)
        {
            Console.WriteLine("The equation has two distinct real roots: {0} and {1}", roots[0].ToString("F2"), roots[1].ToString("F2"));
        }
        else if (roots.Length == 1)
        {
            Console.WriteLine("The equation has one real root: {0}", roots[0].ToString("F2"));
        }
        else
        {
            Console.WriteLine("The equation has no real roots.");
        }
    }
}
