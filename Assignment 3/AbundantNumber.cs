using System;

class AbundantNumber {
	public static void Main()
    {
        // Take input from the user
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to check if the number is an Abundant Number
        if (IsAbundantNumber(number))
        {
            Console.WriteLine("{0} is an Abundant Number.", number);
        }
        else
        {
            Console.WriteLine("{0} is not an Abundant Number.", number);
        }
    }

    // Method to check if a number is an Abundant Number
    static bool IsAbundantNumber(int number)
    {
        int sum = 0; // Initialize sum to 0

        // Use a for loop to find all divisors of the number
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0) // Check if i is a divisor of the number
            {
                sum += i; // Add the divisor to the sum
            }
        }

        // Check if the sum of divisors is greater than the number
        return sum > number;
    }
}