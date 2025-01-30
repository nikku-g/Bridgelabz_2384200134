using System;

public class NumberChecker2
{
    public static void Main(string[] args)
    {
        // Prompt the user for input
        Console.Write("Enter a number : ");
        int number;

        // Ensure valid integer input from the user
        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Invalid input. Please enter a non-negative integer: ");
        }

        Console.WriteLine($"Number: {number}\n");

        // Get the count of digits and store digits in an array
        int digitCount = GetDigitCount(number);
        int[] digits = GetDigitsArray(number);

        // Display the count of digits
        Console.WriteLine($"Count of Digits: {digitCount}");
        Console.WriteLine("Digits: " + string.Join(", ", digits));

        // Reverse the digits array and display
        int[] reversedDigits = ReverseDigitsArray(digits);
        Console.WriteLine("Reversed Digits: " + string.Join(", ", reversedDigits));

        // Check if the number is a palindrome
        bool isPalindrome = IsPalindrome(digits);
        Console.WriteLine($"Is Palindrome: {isPalindrome}");

        // Check if the number is a duck number
        bool isDuck = IsDuckNumber(digits);
        Console.WriteLine($"Is Duck Number: {isDuck}");

        // Compare original and reversed arrays
        bool arraysEqual = AreArraysEqual(digits, reversedDigits);
        Console.WriteLine($"Original and Reversed Arrays are Equal: {arraysEqual}");
    }

    // Method to get the count of digits in the number
    public static int GetDigitCount(int num)
    {
        // Convert the number to a string and return its length
        return num.ToString().Length;
    }

    // Method to store the digits of the number in an array
    public static int[] GetDigitsArray(int num)
    {
        // Convert the number to a string representation
        string numStr = num.ToString();
        int[] digits = new int[numStr.Length];

        // Parse each character to an integer and store in the array
        for (int i = 0; i < numStr.Length; i++)
        {
            digits[i] = int.Parse(numStr[i].ToString());
        }
        return digits;
    }

    // Method to reverse the digits array
    public static int[] ReverseDigitsArray(int[] digits)
    {
        int length = digits.Length;
        int[] reversed = new int[length];

        // Fill the reversed array by iterating from the end of the original array
        for (int i = 0; i < length; i++)
        {
            reversed[i] = digits[length - i - 1];
        }
        return reversed;
    }

    // Method to compare two arrays and check if they are equal
    public static bool AreArraysEqual(int[] array1, int[] array2)
    {
        // Check if arrays have different lengths
        if (array1.Length != array2.Length) return false;

        // Compare each corresponding element in both arrays
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i]) return false;
        }
        return true;
    }

    // Method to check if a number is a palindrome
    public static bool IsPalindrome(int[] digits)
    {
        int length = digits.Length;

        // Compare elements from the beginning and end moving towards the center
        for (int i = 0; i < length / 2; i++)
        {
            if (digits[i] != digits[length - i - 1]) return false;
        }
        return true;
    }

    // Method to check if a number is a duck number (contains zero but not at the start)
    public static bool IsDuckNumber(int[] digits)
    {
        // Start from index 1 to ignore leading zeros
        for (int i = 1; i < digits.Length; i++)
        {
            if (digits[i] == 0)
            {
                return true;
            }
        }
        return false;
    }
}