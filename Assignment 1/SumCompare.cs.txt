using System;

class SumCompare
{
    public static void Main(string[] args)
    {
        // Take user input for the number
        Console.Write("Enter a natural number: ");
		int number = Convert.ToInt32(Console.ReadLine());
		if(number <= 0) {
			Console.WriteLine("Invalid input! Please enter a positive integer.");
            return;
		}

        // Calculate the sum using recursion
        int recursiveSum = SumUsingRecursion(number);

        // Calculate the sum using the formula
        int formulaSum = SumUsingFormula(number);

        // Display the results
        Console.WriteLine("Sum using recursion: {0}", recursiveSum);
        Console.WriteLine("Sum using formula (n*(n+1)/2): {0}", formulaSum);

        // Compare the results
        if (recursiveSum == formulaSum)
        {
            Console.WriteLine("Both results are correct and match!");
        }
        else
        {
            Console.WriteLine("The results do not match. Please check the methods.");
        }
    }

    // Method to find the sum of n natural numbers using recursion
    static int SumUsingRecursion(int n)
    {
        if (n == 1) // Base case
        {
            return 1;
        }
        return n + SumUsingRecursion(n - 1); // Recursive step
    }

    // Method to find the sum of n natural numbers using the formula
    static int SumUsingFormula(int n)
    {
        return n * (n + 1) / 2;
    }
}
