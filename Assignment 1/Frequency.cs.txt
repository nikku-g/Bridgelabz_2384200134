using System;

class Frequency
{
    public static void Main(string[] args)
    {
        // Take input for a number
        Console.Write("Enter a number: ");
		int number = Convert.ToInt32(Console.ReadLine());
		if(number < 0 || number > int.MaxValue) {
			Console.Error.WriteLine("Please enter a valid positive integer.");
			Environment.Exit(0);
		}

        // Find the frequency of each digit in the number
        int[] frequency = new int[10]; // Array to store frequency of digits 0-9
        FindDigitFrequency(number, frequency);

        // Display the frequency of each digit
        Console.WriteLine("\nFrequency of each digit:");
        for (int i = 0; i < frequency.Length; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine("Digit {0}: {1}", i, frequency[i]);
            }
        }
    }

    // Method to find the frequency of digits in the number
    static void FindDigitFrequency(int number, int[] frequency)
    {
        while (number > 0)
        {
            int digit = number % 10; // Extract the last digit
            frequency[digit]++;      // Increment the frequency of the digit
            number /= 10;            // Remove the last digit
        }
    }
}
