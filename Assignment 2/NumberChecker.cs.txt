using System;

public class NumberChecker
{
    public static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        
        // Get user input and convert to integer
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int result = CheckNumberSign(number);
            
            // Display the result based on the return value
            if (result == 1)
                Console.WriteLine("The number is positive.");
            else if (result == -1)
                Console.WriteLine("The number is negative.");
            else
                Console.WriteLine("The number is zero.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    // Method to check if number is positive, negative, or zero
    static int CheckNumberSign(int num)
    {
        if (num > 0)
            return 1;
        else if (num < 0)
            return -1;
        else
            return 0;
    }
}