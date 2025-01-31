using System;

class GCDLCMCalculator
{
    // Function to calculate the GCD (Greatest Common Divisor) using Euclidean algorithm
    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;  // Modulo operation to find remainder
            a = temp;   // Set a to b for next iteration
        }
        return a; // GCD is the last non-zero remainder
    }

    // Function to calculate the LCM (Least Common Multiple)
    static int CalculateLCM(int a, int b, int gcd)
    {
        return (a * b) / gcd; // LCM formula: (a * b) / GCD(a, b)
    }

    // Function to get input from the user
     static int GetInput(string prompt)
    {
        int number;
        Console.WriteLine(prompt);
        while (true)
        {
            // Try to parse the user input as an integer
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    // Function to display the results
    static void DisplayResults(int gcd, int lcm)
    {
        Console.WriteLine("The GCD is: "+gcd);
        Console.WriteLine("The LCM is: "+lcm);
    }

    // Main function that drives the program
    static void Main(string[] args)
    {
        // Get user input
        int num1 = GetInput("enter a first number");
		int num2 = GetInput("enter a secomd number");

        // Calculate the GCD using the CalculateGCD function
        int gcd = CalculateGCD(num1, num2);

        // Calculate the LCM using the CalculateLCM function
        int lcm = CalculateLCM(num1, num2, gcd);

        // Display the results
        DisplayResults(gcd, lcm);
    }
}
