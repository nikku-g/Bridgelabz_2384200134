using System;

public class SelectionSort
{
    // Method to perform Selection Sort
    public void SortExamScores(int[] scores)
    {
        // Traverse through all array elements
        for (int i = 0; i < scores.Length - 1; i++)
        {
            // Find the minimum element in the unsorted part of the array
            int minIndex = i;

            for (int j = i + 1; j < scores.Length; j++)
            {
                // If the current element is smaller than the min element, update minIndex
                if (scores[j] < scores[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first unsorted element
            Swap(scores, i, minIndex);
        }
    }

    // Method to swap two elements in the array
    private void Swap(int[] scores, int i, int j)
    {
        int temp = scores[i];
        scores[i] = scores[j];
        scores[j] = temp;
    }

    // Helper method to print the array
    public void PrintArray(int[] arr)
    {
        foreach (var score in arr)
        {
            Console.Write(score + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        SelectionSort sorter = new SelectionSort();

        // Example: Student exam scores
        int[] scores = { 85, 72, 90, 65, 78, 88, 95 };

        Console.WriteLine("Exam Scores before sorting:");
        sorter.PrintArray(scores);

        // Sort the exam scores using Selection Sort
        sorter.SortExamScores(scores);

        Console.WriteLine("Exam Scores after sorting:");
        sorter.PrintArray(scores);
    }
}
