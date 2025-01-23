using System;

class GreatestFactor {
	public static void Main()
    {
        // Input a number from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to find the greatest factor
        int greatestFactor = FindGreatestFactor(number);

        // Display the greatest factor
        Console.WriteLine("The greatest factor of {0} (besides itself) is: {1}", number, greatestFactor);
    }

    // Method to find the greatest factor of a number (besides itself)
    static int FindGreatestFactor(int number)
    {
        int greatestFactor = 1; // Initialize greatestFactor to 1

        // Loop to find the greatest factor
        for (int i = number - 1; i > 0; i--)
        {
            if (number % i == 0) // Check if number is divisible by i
            {
                greatestFactor = i; // Assign the value to greatestFactor
                break; // Exit the loop as we found the greatest factor
            }
        }

        return greatestFactor; // Return the greatest factor
    }
}