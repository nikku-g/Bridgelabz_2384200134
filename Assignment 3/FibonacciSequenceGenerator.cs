using System;

class FibonacciSequenceGenerator
{
    // Function to generate and print the Fibonacci sequence up to n terms
    static void PrintFibonacci(int n)
    {
        int a = 0, b = 1, next;

        Console.WriteLine("Fibonacci sequence up to " + n + " terms:");

        // Handle edge cases for n <= 0
        if (n <= 0)
        {
            Console.WriteLine("Please enter a positive integer greater than 0.");
            return;
        }

        // Print the Fibonacci sequence
        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");

            // Calculate the next term
            next = a + b;
            a = b;
            b = next;
        }

        Console.WriteLine(); // Newline after the sequence
    }

    // Main function to drive the program
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of terms in the Fibonacci sequence:");
		int terms;

        // Get user input and try to parse it as an integer
        if (int.TryParse(Console.ReadLine(), out terms))
        {
            // Call the PrintFibonacci function to generate and print the sequence
            PrintFibonacci(terms);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}
