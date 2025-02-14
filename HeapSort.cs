using System;

public class HeapSort
{
    // Method to perform Heap Sort
    public void SortSalaries(int[] salaries)
    {
        int n = salaries.Length;

        // Build a Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(salaries, n, i);
        }

        // Extract elements one by one from the heap
        for (int i = n - 1; i >= 0; i--)
        {
            // Move current root to the end
            Swap(salaries, 0, i);

            // Call heapify on the reduced heap
            Heapify(salaries, i, 0);
        }
    }

    // Method to heapify a subtree rooted at index i
    private void Heapify(int[] salaries, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // Left child
        int right = 2 * i + 2; // Right child

        // If left child is larger than root
        if (left < n && salaries[left] > salaries[largest])
        {
            largest = left;
        }

        // If right child is larger than largest so far
        if (right < n && salaries[right] > salaries[largest])
        {
            largest = right;
        }

        // If largest is not root
        if (largest != i)
        {
            Swap(salaries, i, largest);

            // Recursively heapify the affected subtree
            Heapify(salaries, n, largest);
        }
    }

    // Method to swap two elements in the array
    private void Swap(int[] salaries, int i, int j)
    {
        int temp = salaries[i];
        salaries[i] = salaries[j];
        salaries[j] = temp;
    }

    // Helper method to print the array
    public void PrintArray(int[] arr)
    {
        foreach (var salary in arr)
        {
            Console.Write(salary + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        HeapSort sorter = new HeapSort();

        // Example: Salary demands of job applicants
        int[] salaries = { 55000, 70000, 60000, 45000, 80000, 75000, 65000 };

        Console.WriteLine("Salary demands before sorting:");
        sorter.PrintArray(salaries);

        // Sort the salary demands using Heap Sort
        sorter.SortSalaries(salaries);

        Console.WriteLine("Salary demands after sorting:");
        sorter.PrintArray(salaries);
    }
}
