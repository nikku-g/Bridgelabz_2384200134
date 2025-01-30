using System;

public class ChocolateDistributor
{
    public static void Main(string[] args)
    {
		// Taking user input to enter the total number of chocolates
        Console.Write("Enter the total number of chocolates: ");
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        // Taking user input to enter the total number of children
        Console.Write("Enter the number of children: ");
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        // Ensure number of children is not zero to avoid division by zero
        if (numberOfChildren == 0)
        {
            Console.WriteLine("Error: Number of children cannot be zero.");
            return;
        }

        // Call the method to calculate chocolates per child and remainder
        int[] result = FindRemainderAndQuotient(numberOfChocolates, numberOfChildren);

        Console.WriteLine("\nEach child will get: {0} chocolates", result[0]);
        Console.WriteLine("Remaining chocolates: {0}", result[1]);
    }

    // Method to find how many chocolates each child gets and the remainder
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;  // Chocolates each child will get
        int remainder = number % divisor; // Remaining chocolates

        return new int[] { quotient, remainder };
    }
}