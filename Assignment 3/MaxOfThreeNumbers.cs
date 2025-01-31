using System;

class MaxOfThreeNumbers
{
    // Function to take an integer input from the user
    static int GetInput(string prompt)
    {
        int number;
        Console.WriteLine(prompt);
        while (true)
        {
            // Try to parse the user input as an integer
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    // Function to calculate the maximum of three integers
    static int FindMax(int num1, int num2, int num3)
    {
        if (num1 >= num2 && num1 >= num3)
            return num1;
        else if (num2 >= num1 && num2 >= num3)
            return num2;
        else
            return num3;
    }

    // Main function that drives the program
    static void Main(string[] args)
    {
        // Get three integers from the user
        int num1 = GetInput("Enter the first number:");
        int num2 = GetInput("Enter the second number:");
        int num3 = GetInput("Enter the third number:");

        // Find the maximum number using the FindMax function
        int maxNumber = FindMax(num1, num2, num3);

        // Display the result
        Console.WriteLine("The maximum of {0}, {1}, and {2} is {3}.",num1, num2, num3, maxNumber);
    }
}
