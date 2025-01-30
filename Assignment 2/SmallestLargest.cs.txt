using System;

public class SmallestLargest
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter three integers:");

        // Get user input for three numbers
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        // Call the method to find smallest and largest numbers
        int[] result = FindSmallestAndLargest(num1, num2, num3);

        Console.WriteLine("Smallest number: {0}", result[0]);
        Console.WriteLine("Largest number: {0}", result[1]);
    }

    // Method to find the smallest and largest of three numbers
    public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
    {
        int smallest = Math.Min(number1, Math.Min(number2, number3));
        int largest = Math.Max(number1, Math.Max(number2, number3));

        return new int[] { smallest, largest };
    }
}