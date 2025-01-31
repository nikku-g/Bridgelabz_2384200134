using System;

class BasicCalculator
{
    // Function for addition
    static double Add(double a, double b)
    {
        return a + b;
    }

    // Function for subtraction
    static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Function for multiplication
    static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Function for division
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error! Division by zero is not allowed.");
            return double.NaN; // Return Not-a-Number if division by zero
        }
        return a / b;
    }

    // Function to get user input
    static (double, double) GetInput()
    {
        double num1, num2;
        while (true)
        {
            Console.Write("Enter the first number: ");
            if (double.TryParse(Console.ReadLine(), out num1))
                break;
            else
                Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        while (true)
        {
            Console.Write("Enter the second number: ");
            if (double.TryParse(Console.ReadLine(), out num2))
                break;
            else
                Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        return (num1, num2);
    }

    // Function to display the result of the operation
    static void DisplayResult(string operation, double result)
    {
        Console.WriteLine("The result of the "+operation+" is: "+result);
    }

    // Main function to drive the program
    static void Main(string[] args)
    {
        Console.WriteLine("Basic Calculator");
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        int choice;
        while (true)
        {
            Console.Write("Enter the number of the operation (1-4): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
                break;
            else
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 4.");
        }

        // Get input values from the user
        var (num1, num2) = GetInput();

        double result = 0;

        switch (choice)
        {
            case 1:
                result = Add(num1, num2);
                DisplayResult("addition", result);
                break;
            case 2:
                result = Subtract(num1, num2);
                DisplayResult("subtraction", result);
                break;
            case 3:
                result = Multiply(num1, num2);
                DisplayResult("multiplication", result);
                break;
            case 4:
                result = Divide(num1, num2);
                if (!double.IsNaN(result)) // Only display if the result is valid
                    DisplayResult("division", result);
                break;
        }
    }
}
