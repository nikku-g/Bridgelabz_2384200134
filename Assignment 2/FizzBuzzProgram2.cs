using System;

class FizzBuzzProgram2
{
    public static void Main()
    {
        // Get input from the user
        Console.Write("Enter a positive integer: ");
        int number = int.Parse(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
        }
        else
        {
            // Call the FizzBuzz method to print the sequence
            FizzBuzz(number);
        }
    }

    // Method to print FizzBuzz
    static void FizzBuzz(int number)
    {
		int i = 1;
        while(i <= number)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");  // Multiple of both 3 and 5
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");  // Multiple of 3
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");  // Multiple of 5
            }
            else
            {
                Console.WriteLine(i);  // Print the number itself
            }
			i++;
        }
    }
}
