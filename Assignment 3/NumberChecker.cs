using System;

public class NumberChecker
{
    public static void Main(string[] args)
    {
        // Prompt the user to enter a number
        Console.Write("Enter a number: ");
        int number;
        
        // Ensure the user input is a valid integer
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }

        // Display the number entered by the user
        Console.WriteLine($"Number: {number}");

        // Find and display the count of digits in the number
        int digitCount = GetDigitCount(number);
        Console.WriteLine($"Count of Digits: {digitCount}");

        // Store the digits of the number in an array
        int[] digits = GetDigitsArray(number);
        Console.WriteLine("Digits in the Number: " + string.Join(", ", digits));

        // Check if the number is a Duck Number 
        bool isDuck = IsDuckNumber(digits);
        Console.WriteLine($"Is Duck Number: {isDuck}");

        // Check if the number is an Armstrong number
        bool isArmstrong = IsArmstrongNumber(digits, number);
        Console.WriteLine($"Is Armstrong Number: {isArmstrong}");

        // Find and display the largest and second largest digits in the number
        (int largest, int secondLargest) = FindLargestAndSecondLargest(digits);
        Console.WriteLine($"Largest Digit: {largest}, Second Largest Digit: {secondLargest}");

        // Find and display the smallest and second smallest digits in the number
        (int smallest, int secondSmallest) = FindSmallestAndSecondSmallest(digits);
        Console.WriteLine($"Smallest Digit: {smallest}, Second Smallest Digit: {secondSmallest}");
    }

    // Method to find the count of digits in the number
    public static int GetDigitCount(int num)
    {
        // Convert the number to a string and return its length, which gives the number of digits
        return num.ToString().Length;
    }

    // Method to store the digits of the number in an array
    public static int[] GetDigitsArray(int num)
    {
        // Convert the number to a string to easily access each digit
        string numStr = num.ToString();
        int[] digits = new int[numStr.Length];

        for (int i = 0; i < numStr.Length; i++)
        {
            digits[i] = int.Parse(numStr[i].ToString());
        }

        // Return the array containing all the digits
        return digits;
    }

    // Method to check if a number is a Duck Number
    public static bool IsDuckNumber(int[] digits)
    {
        // Loop through the digits
        for (int i = 1; i < digits.Length; i++)
        {
            if (digits[i] == 0) // Check if any of the digits is zero
            {
                return true;  // If a non-leading zero is found, it's a Duck Number
            }
        }
        return false; 
    }

    // Method to check if the number is an Armstrong number
    public static bool IsArmstrongNumber(int[] digits, int originalNumber)
    {
        int power = digits.Length;  // The number of digits determines the power
        int sum = 0;

        // Sum the digits raised to the power of the number of digits
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, power);  // Raise each digit to the power of 'power' and add it to the sum
        }

        // If the sum equals the original number, it's an Armstrong number
        return sum == originalNumber;
    }

    // Method to find the largest and second largest digits
    public static (int, int) FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;  // Start with the smallest possible value
        int secondLargest = Int32.MinValue;  // Start with the smallest possible value

        // Loop through the digits array to find the largest and second largest
        foreach (int digit in digits)
        {
            if (digit > largest)  // If the current digit is larger than the largest, update both values
            {
                secondLargest = largest;
                largest = digit;
            }
            else if (digit > secondLargest && digit < largest)  // If the current digit is smaller than largest but larger than second largest
            {
                secondLargest = digit;
            }
        }

        // Return the largest and second largest digits
        return (largest, secondLargest);
    }

    // Method to find the smallest and second smallest digits
    public static (int, int) FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue;  // Start with the largest possible value
        int secondSmallest = Int32.MaxValue;  // Start with the largest possible value

        // Loop through the digits array to find the smallest and second smallest
        foreach (int digit in digits)
        {
            if (digit < smallest)  // If the current digit is smaller than the smallest, update both values
            {
                secondSmallest = smallest;
                smallest = digit;
            }
            else if (digit < secondSmallest && digit > smallest)  // If the current digit is larger than smallest but smaller than second smallest
            {
                secondSmallest = digit;
            }
        }

        // Return the smallest and second smallest digits
        return (smallest, secondSmallest);
    }
}