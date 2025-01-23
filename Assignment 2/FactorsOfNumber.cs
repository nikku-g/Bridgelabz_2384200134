using System;

class FactorsOfNumber
{
    public static void Main()
    {
        // Input a number from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to find and display factors
        FindFactors(number);
    }

    // Method to find and print the factors of a number
    static void FindFactors(int number)
    {
        Console.WriteLine("The factors of {0} are:", number);

        // Loop to find all factors of the number
        for (int i = 1; i <= number; i++) // Include the number itself
        {
            if (number % i == 0) // Check if i is a factor
            {
                Console.WriteLine(i); // Print the factor
            }
        }
    }
}
