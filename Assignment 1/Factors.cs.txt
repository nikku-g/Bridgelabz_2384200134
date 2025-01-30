using System;

class Factors
{
    public static void Main(string[] args)
    {
        // Take user input for the number
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Get the factors of the number
        int[] factors = GetFactors(number);

        // Display the factors
        Console.WriteLine("Factors: " + string.Join(", ", factors));

        // Calculate and display the sum of the factors
        int sum = GetSumOfFactors(factors);
        Console.WriteLine("Sum of factors: " + sum);

        // Calculate and display the sum of squares of the factors
        int sumOfSquares = GetSumOfSquareOfFactors(factors);
        Console.WriteLine("Sum of squares of factors: " + sumOfSquares);

        // Calculate and display the product of the factors
        long product = GetProductOfFactors(factors);
        Console.WriteLine("Product of factors: " + product);
    }

    // Method to find the factors of a number and return them as an array
    static int[] GetFactors(int number)
    {
        // First loop: Count the factors
        int count = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }

        // Initialize the array with the count of factors
        int[] factors = new int[count];

        // Second loop: Save the factors into the array
        int index = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[index++] = i;
            }
        }

        return factors;
    }

    // Method to find the sum of factors
    static int GetSumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }

    // Method to find the sum of the squares of factors
    static int GetSumOfSquareOfFactors(int[] factors)
    {
        int sumOfSquares = 0;
        foreach (int factor in factors)
        {
            sumOfSquares += (int)Math.Pow(factor, 2);
        }
        return sumOfSquares;
    }

    // Method to find the product of factors
    static long GetProductOfFactors(int[] factors)
    {
        long product = 1;
        foreach (int factor in factors)
        {
            product *= factor;
        }
        return product;
    }
}
