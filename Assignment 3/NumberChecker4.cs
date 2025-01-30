using System;
using System.Linq;

public class NumberChecker4
{
    public static void Main(string[] args)
    {
        // Prompt the user for input
        Console.Write("Enter a positive integer: ");
        int number;

        // Validate input to ensure it's a positive integer
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer: ");
        }

        Console.WriteLine($"\nNumber: {number}\n");

        // Display factors of the number
        int[] factors = GetFactors(number);
        Console.WriteLine("Factors: " + string.Join(", ", factors));

        // Display other properties of the number
        Console.WriteLine($"Greatest Factor: {GetGreatestFactor(factors)}");
        Console.WriteLine($"Sum of Factors: {GetSumOfFactors(factors)}");
        Console.WriteLine($"Product of Factors: {GetProductOfFactors(factors)}");
        Console.WriteLine($"Product of Cube of Factors: {GetProductOfCubeOfFactors(factors)}");
        Console.WriteLine($"Is Perfect Number: {IsPerfectNumber(number)}");
        Console.WriteLine($"Is Abundant Number: {IsAbundantNumber(number)}");
        Console.WriteLine($"Is Deficient Number: {IsDeficientNumber(number)}");
        Console.WriteLine($"Is Strong Number: {IsStrongNumber(number)}");
    }

    // Method to find factors of a number
    public static int[] GetFactors(int num)
    {
        int count = 0;

        // First loop to count the number of factors
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        // Second loop to store factors
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
                factors[index++] = i;
        }

        return factors;
    }

    // Method to find the greatest factor
    public static int GetGreatestFactor(int[] factors)
    {
        int greatest = factors[0];
        foreach (var factor in factors)
        {
            if (factor > greatest)
            {
                greatest = factor;
            }
        }
        return greatest;
    }

    // Method to find the sum of factors
    public static int GetSumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (var factor in factors)
        {
            sum += factor;
        }
        return sum;
    }

    // Method to find the product of factors
    public static long GetProductOfFactors(int[] factors)
    {
        long product = 1;
        foreach (var factor in factors)
        {
            product *= factor;
        }
        return product;
    }

    // Method to find the product of the cube of factors
    public static double GetProductOfCubeOfFactors(int[] factors)
    {
        double product = 1;
        foreach (var factor in factors)
        {
            product *= Math.Pow(factor, 3);
        }
        return product;
    }

    // Method to check if a number is a perfect number
    public static bool IsPerfectNumber(int num)
    {
        int sumOfDivisors = 0;
        foreach (var divisor in GetProperDivisors(num))
        {
            sumOfDivisors += divisor;
        }
        return sumOfDivisors == num;
    }

    // Method to check if a number is an abundant number
    public static bool IsAbundantNumber(int num)
    {
        int sumOfDivisors = 0;
        foreach (var divisor in GetProperDivisors(num))
        {
            sumOfDivisors += divisor;
        }
        return sumOfDivisors > num;
    }

    // Method to check if a number is a deficient number
    public static bool IsDeficientNumber(int num)
    {
        int sumOfDivisors = 0;
        foreach (var divisor in GetProperDivisors(num))
        {
            sumOfDivisors += divisor;
        }
        return sumOfDivisors < num;
    }

    // Method to check if a number is a strong number
    public static bool IsStrongNumber(int num)
    {
        int sumOfFactorials = 0;
        int originalNum = num;

        // Loop through each digit and calculate factorial of the digit
        while (num > 0)
        {
            int digit = num % 10;
            sumOfFactorials += Factorial(digit);
            num /= 10;
        }

        // Check if the sum of factorials equals the original number
        return sumOfFactorials == originalNum;
    }

    // Method to calculate factorial of a number
    public static int Factorial(int n)
    {
        if (n == 0 || n == 1) return 1;
        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    // Method to get proper divisors (excluding the number itself)
    public static int[] GetProperDivisors(int num)
    {
        // Create an array of size num / 2 (since the number itself is not included)
        int[] divisors = new int[num / 2];
        int count = 0;

        // Loop through numbers from 1 to num / 2 to find divisors
        for (int i = 1; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                divisors[count] = i;  // Add divisor to the array
                count++;  // Increment the count of divisors found
            }
        }

        // Return only the relevant portion of the array (divisors found)
        return divisors.ToArray();
    }
}