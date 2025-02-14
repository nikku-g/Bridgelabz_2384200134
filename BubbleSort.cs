using System;

public class BubbleSort
{
    // Method to implement Bubble Sort
    public void SortStudentMarks(int[] marks)
    {
        int n = marks.Length;
        bool swapped;

        // Traverse through all array elements
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            // Last i elements are already sorted
            for (int j = 0; j < n - i - 1; j++)
            {
                // Compare the adjacent elements
                if (marks[j] > marks[j + 1])
                {
                    // Swap if the current element is greater than the next element
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;

                    swapped = true;
                }
            }

            // If no two elements were swapped by inner loop, then the array is already sorted
            if (!swapped)
                break;
        }
    }

    // Helper method to print the sorted array
    public void PrintArray(int[] arr)
    {
        foreach (int mark in arr)
        {
            Console.Write(mark + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        BubbleSort bubbleSort = new BubbleSort();

        // Example: Student marks
        int[] marks = { 75, 89, 42, 56, 91, 67, 80 };

        Console.WriteLine("Student Marks before sorting:");
        bubbleSort.PrintArray(marks);

        // Sort the student marks using Bubble Sort
        bubbleSort.SortStudentMarks(marks);

        Console.WriteLine("Student Marks after sorting:");
        bubbleSort.PrintArray(marks);
    }
}
