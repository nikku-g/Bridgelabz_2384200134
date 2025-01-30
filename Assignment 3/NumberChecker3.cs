using System;

public class NumberChecker3
{
    public static void Main(string[] args)
    {
        // Prompt the user for input
        Console.Write("Enter a number (non-negative expected): ");
        int number;

        // Ensure valid integer input from the user
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        Console.WriteLine($"Number: {number}\n");

        // Check if the number is a prime number
        bool isPrime = IsPrimeNumber(number);
        Console.WriteLine($"Is Prime Number: {isPrime}");

        // Check if the number is a neon number
        bool isNeon = IsNeonNumber(number);
        Console.WriteLine($"Is Neon Number: {isNeon}");

        // Check if the number is a spy number
        bool isSpy = IsSpyNumber(number);
        Console.WriteLine($"Is Spy Number: {isSpy}");

        // Check if the number is an automorphic number
        bool isAutomorphic = IsAutomorphicNumber(number);
        Console.WriteLine($"Is Automorphic Number: {isAutomorphic}");

        // Check if the number is a buzz number
        bool isBuzz = IsBuzzNumber(number);
        Console.WriteLine($"Is Buzz Number: {isBuzz}");
    }

    // Method to check if a number is a prime number
    public static bool IsPrimeNumber(int num)
    {
        if (num <= 1) return false;

        // Check divisibility up to the square root of the number
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

    // Method to check if a number is a neon number
    public static bool IsNeonNumber(int num)
    {
        int square = num * num;
        int sumOfDigits = 0;

        // Calculate the sum of the digits of the square
        while (square > 0)
        {
            sumOfDigits += square % 10;
            square /= 10;
        }
        return sumOfDigits == num;
    }

    // Method to check if a number is a spy number
    public static bool IsSpyNumber(int num)
    {
        int sum = 0, product = 1;

        // Calculate the sum and product of the digits
        while (num > 0)
        {
            int digit = num % 10;
            sum += digit;
            product *= digit;
            num /= 10;
        }
        return sum == product;
    }

    // Method to check if a number is an automorphic number
    public static bool IsAutomorphicNumber(int num)
    {
        int square = num * num;
        
        // Keep reducing the square and number to check the last digits
        while (square > 0)
        {
            if (square % 10 != num % 10)
            {
                return false;
            }
            square /= 10;
            num /= 10;
        }
        return true;
    }

    // Method to check if a number is a buzz number
    public static bool IsBuzzNumber(int num)
    {
        // Check divisibility by 7 or if the last digit is 7
        return num % 7 == 0 || num % 10 == 7;
    }
}