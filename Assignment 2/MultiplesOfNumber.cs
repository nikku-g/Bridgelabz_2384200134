using System;

class MultiplesOfNumber
{
    static void Main()
    {
        // Input a number from the user
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        // Call the method to find and display the multiples
        FindMultiples(number);
    }

    // Method to find and print all multiples of a number below 100
    static void FindMultiples(int number)
    {
        Console.WriteLine("The multiples of {0} below 100 are:", number);

        // Loop backward from 100 to 1
        for (int i = 100; i >= 1; i--)
        {
            if (i % number == 0) // Check if i is a multiple of the number
            {
                Console.WriteLine(i); // Print the multiple
            }
        }
    }
}
