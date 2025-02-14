using System;

public class CountingSort
{
    // Method to perform Counting Sort
    public void SortAges(int[] ages)
    {
        int minAge = 10;  // Minimum age
        int maxAge = 18;  // Maximum age

        // Create a count array to store the frequency of each age
        int[] count = new int[maxAge - minAge + 1]; // Array for ages 10 to 18
        int[] output = new int[ages.Length]; // Array to store the sorted output

        // Count the frequency of each age
        for (int i = 0; i < ages.Length; i++)
        {
            count[ages[i] - minAge]++;
        }

        // Update the count array to store cumulative counts
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array by placing ages in the correct positions
        for (int i = ages.Length - 1; i >= 0; i--)
        {
            int age = ages[i];
            output[count[age - minAge] - 1] = age;
            count[age - minAge]--; // Decrease count for this age
        }

        // Copy the sorted output array back to the original array
        for (int i = 0; i < ages.Length; i++)
        {
            ages[i] = output[i];
        }
    }

    // Helper method to print the array
    public void PrintArray(int[] arr)
    {
        foreach (var age in arr)
        {
            Console.Write(age + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        CountingSort sorter = new CountingSort();

        // Example: Ages of students
        int[] ages = { 12, 10, 15, 14, 11, 18, 16, 10, 12, 17, 13, 14 };

        Console.WriteLine("Student ages before sorting:");
        sorter.PrintArray(ages);

        // Sort the ages using Counting Sort
        sorter.SortAges(ages);

        Console.WriteLine("Student ages after sorting:");
        sorter.PrintArray(ages);
    }
}
