using System;

class Program
{
    static void Main()
    {
        try
        {
            // Taking user input for array size
            Console.WriteLine("Enter the size of the array:");
            int size = Int32.Parse(Console.ReadLine());
            int[] numbers = new int[size];

            // Taking array elements from user
            Console.WriteLine("Enter " + size + " elements:");
            for (int i = 0; i < size; i++)
            {
                numbers[i] = Int32.Parse(Console.ReadLine());
            }

            // Taking user input for index
            Console.WriteLine("Enter the index to access:");
            int index = Int32.Parse(Console.ReadLine());

            try
            {
                // Access the element at the given index
                int element = numbers[index];

                try
                {
                    // Taking divisor input
                    Console.WriteLine("Enter the divisor:");
                    int divisor = Int32.Parse(Console.ReadLine());

                    // Performing division
                    int result = element / divisor;
                    Console.WriteLine("Result: " + result);
                }
                catch (DivideByZeroException)
                {
                    // Handle division by zero
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                // Handle invalid index access
                Console.WriteLine("Invalid array index!");
            }
        }
        catch (FormatException)
        {
            // Handle invalid input format
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }
    }
}