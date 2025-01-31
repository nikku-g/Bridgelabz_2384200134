using System;

class FactorialCalculator
{
    // Function to get the user input
    static int GetInput()
    {
        Console.WriteLine("Enter a number to calculate its factorial:");
        int number;

        // Validate input
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }

        return number;
    }

    // Recursive function to calculate the factorial
    static long CalculateFactorial(int n)
    {
        if (n == 0) // Base case: factorial of 0 is 1
            return 1;
        else
            return n * CalculateFactorial(n - 1); // Recursive case
    }

    // Function to display the result
    static void DisplayResult(int number, long factorial)
    {
        Console.WriteLine("The factorial of {number} is "+factorial);
    }

    // Main function to drive the program
    static void Main(string[] args)
    {
        // Get the input from the user
        int userInput = GetInput();

        // Calculate the factorial using the recursive function
        long result = CalculateFactorial(userInput);

        // Display the result
        DisplayResult(userInput, result);
    }
}
