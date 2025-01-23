using System;

class CountDigits {
		public static void Main() {
        // Take input from the user
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to count the digits
        int digitCount = CountDigits(number);

        // Display the result
        Console.WriteLine("The number of digits is: {0}", digitCount);
    }

    // Method to count the number of digits in an integer using a while loop
    static int CountDigits(int number) {
        int count = 0; // Variable to count the number of digits
        int absoluteNumber = Math.Abs(number); // Take the absolute value to handle negative numbers

        // Use a while loop to count the digits
        while (absoluteNumber != 0)
        {
            // Remove the last digit from the number
            absoluteNumber /= 10;

            // Increment the count
            count++;
        }

        // If the number is 0, count should be 1
        return count == 0 ? 1 : count;
    }
}