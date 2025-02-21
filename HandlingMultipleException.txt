using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = null; // Initially null array

            try
            {
                // Asking user for array size
                Console.WriteLine("Enter the size of the array:");
                int size = Int32.Parse(Console.ReadLine());
                numbers = new int[size];

                // Taking array input from user
                Console.WriteLine("Enter " + size + " elements:");
                for (int i = 0; i < size; i++)
                {
                    numbers[i] = Int32.Parse(Console.ReadLine());
                }

                // Asking user for index input
                Console.WriteLine("Enter the index to retrieve the value:");
                int index = Int32.Parse(Console.ReadLine());

                // Printing the value at the given index
                Console.WriteLine("Value at index " + index + ": " + numbers[index]);
            }
            catch (IndexOutOfRangeException)
            {
                // Handle index out of range exception
                Console.WriteLine("Invalid index!");
            }
            catch (NullReferenceException)
            {
                // Handle null array exception
                Console.WriteLine("Array is not initialized!");
            }
            catch (FormatException)
            {
                // Handle invalid input format
                Console.WriteLine("Invalid input! Please enter numeric values.");
            }
        }
    }
}