using System;

class Calculator {
	public static void Main()
    {
        // Get input values for first number, second number, and operator
        Console.Write("Enter the first number: ");
        double first = double.Parse(Console.ReadLine());

        Console.Write("Enter the operator (+, -, *, /): ");
        string op = Console.ReadLine();

        Console.Write("Enter the second number: ");
        double second = double.Parse(Console.ReadLine());

        // Call the Calculate method and display the result
        double result = Calculate(first, second, op);
        
        // Display result if valid, else print error message
        if (result != double.MinValue) // If it's an invalid operator, we return double.MinValue
        {
            Console.WriteLine("The result of {0} {1} {2} = {3}", first, op, second, result);
        }
        else
        {
            Console.WriteLine("Invalid Operator.");
        }
    }

    // Method to perform calculations based on the operator
    static double Calculate(double first, double second, string op)
    {
        double result = double.MinValue; // Default value to indicate invalid operator

        switch (op)
        {
            case "+":
                result = first + second;
                break;
            case "-":
                result = first - second;
                break;
            case "*":
                result = first * second;
                break;
            case "/":
                if (second != 0)
                {
                    result = first / second;
                }
                else
                {
                    Console.WriteLine("Error: Division by zero.");
                    result = double.MinValue;
                }
                break;
            default:
                // If the operator is invalid, return double.MinValue to indicate an error
                break;
        }

        return result;
    }
}