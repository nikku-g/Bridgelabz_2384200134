using System;

public class QuotientRemainder
{
    public static void Main(string[] args)
    {
		// Taking user input for dividend and divisor
        Console.Write("Enter the dividend (number): ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        // Ensure divisor is not zero to avoid division by zero error
        if (divisor == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return;
        }

        // Call the method to get quotient and remainder
        int[] result = FindRemainderAndQuotient(number, divisor);

        Console.WriteLine("Quotient: {0}", result[0]);
        Console.WriteLine("Remainder: {1}", result[1]);
    }

    // Method to find the remainder and quotient of a number
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;

        // Returning the array containing the calculated quotient and remainder. 
        return new int[] { quotient, remainder };
    }
}