using System;

public class NumberOperations
{
    // Method to check if a number is positive
    public bool IsPositive(int number)
    {
        return number >= 0;
    }

    // Method to check if a number is even
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // Method to compare two numbers
    public int Compare(int number1, int number2)
    {
        if (number1 > number2)
            return 1;
        else if (number1 == number2)
            return 0;
        else
            return -1;
    }
}

class NumberOperator
{
    public static void Main(string[] args)
    {
        int[] numbers = new int[5];
        NumberOperations operations = new NumberOperations();

        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Number {0}: ", i+1);
            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write("Number {0}: ", i+1);
            }
        }

        Console.WriteLine("\nAnalysis of numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (operations.IsPositive(numbers[i]))
            {
                Console.Write("Number {0} is positive and ", numbers[i]);
                if (operations.IsEven(numbers[i]))
                {
                    Console.WriteLine("even.");
                }
                else
                {
                    Console.WriteLine("odd.");
                }
            }
            else
            {
                Console.WriteLine("Number {0} is negative.", numbers[i]);
            }
        }

        // Compare the first and last elements of the array
        Console.WriteLine("\nComparison of the first and last elements:");
        int comparisonResult = operations.Compare(numbers[0], numbers[^1]); // ^1 is the index for the last element
        if (comparisonResult == 1)
        {
            Console.WriteLine("The first element ({0}) is greater than the last element ({1}).", numbers[0], numbers[^1]);
        }
        else if (comparisonResult == 0)
        {
            Console.WriteLine("The first element ({0}) is equal to the last element ({1}).", numbers[0], numbers[^1]);
        }
        else
        {
            Console.WriteLine("The first element ({0}) is less than the last element ({1}).", numbers[0], numbers[^1]);
        }
    }
}
