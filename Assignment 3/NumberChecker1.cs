using System;

public class NumberChecker1
{
    public static void Main(string[] args)
    {
        // Prompt the user for input
        Console.Write("Enter a number: ");
        int number;
        
        // Ensure valid integer input from the user
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }

        Console.WriteLine($"Number: {number}\n");

        // Get the count of digits and store digits in an array
        int digitCount = GetDigitCount(number);
        int[] digits = GetDigitsArray(number);

        // Display the count of digits
        Console.WriteLine($"Count of Digits: {digitCount}");
        Console.WriteLine("Digits: " + string.Join(", ", digits));

        // Calculate and display the sum of digits
        int digitSum = GetSumOfDigits(digits);
        Console.WriteLine($"Sum of Digits: {digitSum}");

        // Calculate and display the sum of squares of digits
        int sumOfSquares = GetSumOfSquaresOfDigits(digits);
        Console.WriteLine($"Sum of Squares of Digits: {sumOfSquares}");

        // Check if the number is a Harshad number
        bool isHarshad = IsHarshadNumber(number, digitSum);
        Console.WriteLine($"Is Harshad Number: {isHarshad}");

        // Find the frequency of each digit and display it
        int[] frequencyArray = GetDigitFrequency(digits);
        Console.WriteLine("\nDigit Frequency Table:");
        for (int i = 0; i < frequencyArray.Length; i++)
        {
            if (frequencyArray[i] > 0)
            {
                Console.WriteLine($"Digit {i}: {frequencyArray[i]} times");
            }
        }
    }

    // Method to get the count of digits in the number
    public static int GetDigitCount(int num)
    {
        // Convert number to string and get its length
        return num.ToString().Length;
    }

    // Method to store the digits of the number in an array
    public static int[] GetDigitsArray(int num)
    {
        string numStr = num.ToString();
        int[] digits = new int[numStr.Length];

        // Parse each character to an integer and store in the array
        for (int i = 0; i < numStr.Length; i++)
        {
            digits[i] = int.Parse(numStr[i].ToString());
        }
        return digits;
    }

    // Method to find the sum of the digits of a number
    public static int GetSumOfDigits(int[] digits)
    {
        int sum = 0;

        // Add each digit to the sum
        foreach (int digit in digits)
        {
            sum += digit;
        }
        return sum;
    }

    // Method to find the sum of squares of the digits of a number
    public static int GetSumOfSquaresOfDigits(int[] digits)
    {
        int sum = 0;

        // Compute the square of each digit and add to the sum
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, 2);
        }
        return sum;
    }

    // Method to check if a number is a Harshad number
    public static bool IsHarshadNumber(int number, int digitSum)
    {
        // A number is a Harshad number if divisible by the sum of its digits
        return number % digitSum == 0;
    }

    // Method to find the frequency of each digit in the number
    public static int[] GetDigitFrequency(int[] digits)
    {
        int[] frequencyArray = new int[10]; // Array to store frequency for digits

        foreach (int digit in digits)
        {
            frequencyArray[digit]++;
        }

        return frequencyArray;
    }
}