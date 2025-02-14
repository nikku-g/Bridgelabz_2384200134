using System;

public class InsertionSort
{
    // Method to implement Insertion Sort
    public void SortEmployeeIDs(int[] employeeIDs)
    {
        int n = employeeIDs.Length;

        // Traverse through elements from index 1 to n-1
        for (int i = 1; i < n; i++)
        {
            int key = employeeIDs[i];  // The element to be inserted
            int j = i - 1;

            // Move elements of employeeIDs[0..i-1], that are greater than key, to one position ahead
            // of their current position
            while (j >= 0 && employeeIDs[j] > key)
            {
                employeeIDs[j + 1] = employeeIDs[j];
                j = j - 1;
            }

            // Place the key in the correct position
            employeeIDs[j + 1] = key;
        }
    }

    // Helper method to print the sorted array
    public void PrintArray(int[] arr)
    {
        foreach (int id in arr)
        {
            Console.Write(id + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        InsertionSort insertionSort = new InsertionSort();

        // Example: Employee IDs
        int[] employeeIDs = { 1025, 1012, 1037, 1003, 1045 };

        Console.WriteLine("Employee IDs before sorting:");
        insertionSort.PrintArray(employeeIDs);

        // Sort the employee IDs using Insertion Sort
        insertionSort.SortEmployeeIDs(employeeIDs);

        Console.WriteLine("Employee IDs after sorting:");
        insertionSort.PrintArray(employeeIDs);
    }
}
