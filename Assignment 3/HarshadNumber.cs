using System;

class HarshadNumber {
	public static void Main()
    {
        // Take input from the user
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to check if the number is a Harshad Number
        if (IsHarshadNumber(number))
        {
            Console.WriteLine("{0} is a Harshad Number.", number);
        }
        else
        {
            Console.WriteLine("{0} is not a Harshad Number.", number);
        }
    }

    // Method to check if a number is a Harshad Number
    static bool IsHarshadNumber(int number)
    {
        int sum = 0; // Initialize sum to 0
        int originalNumber = Math.Abs(number); // Take absolute value to handle negative numbers

        // Use a while loop to calculate the sum of digits
        while (originalNumber != 0)
        {
            int digit = originalNumber % 10; // Extract the last digit
            sum += digit; // Add the digit to the sum
            originalNumber /= 10; // Remove the last digit
        }

        // Check if the number is divisible by the sum of its digits
        return number % sum == 0;
    }
}