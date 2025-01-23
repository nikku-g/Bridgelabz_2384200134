using System;

class Armstrong {
	public static void Main()
    {
        // Take input from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to check if the number is an Armstrong number
        if (IsArmstrongNumber(number))
        {
            Console.WriteLine("{0} is an Armstrong number.", number);
        }
        else
        {
            Console.WriteLine("{0} is not an Armstrong number.", number);
        } 
    }

    // Method to check if a number is an Armstrong number
    static bool IsArmstrongNumber(int number)
    {
        int sum = 0; // Sum of cubes of digits
        int originalNumber = number; // Store the original number

        // While loop to process each digit
        while (originalNumber != 0)
        {
            int digit = originalNumber % 10; // Get the last digit
            sum += digit * digit * digit; // Add the cube of the digit to the sum
            originalNumber /= 10; // Remove the last digit
        }

        // Return true if the sum equals the original number, otherwise false
        return sum == number;
    }
}