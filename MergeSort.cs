using System;

public class MergeSort
{
    // Method to implement Merge Sort
    public void SortBookPrices(int[] prices)
    {
        // Call the merge sort function on the entire array
        MergeSortArray(prices, 0, prices.Length - 1);
    }

    // Helper method to perform merge sort recursively
    private void MergeSortArray(int[] prices, int left, int right)
    {
        if (left < right)
        {
            // Find the middle point of the array
            int mid = left + (right - left) / 2;

            // Recursively sort the first half
            MergeSortArray(prices, left, mid);

            // Recursively sort the second half
            MergeSortArray(prices, mid + 1, right);

            // Merge the two sorted halves
            Merge(prices, left, mid, right);
        }
    }

    // Helper method to merge two sorted sub-arrays
    private void Merge(int[] prices, int left, int mid, int right)
    {
        // Find the sizes of the two sub-arrays to be merged
        int n1 = mid - left + 1;
        int n2 = right - mid;

        // Create temporary arrays to hold the values
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays leftArray[] and rightArray[]
        for (int i = 0; i < n1; i++)
        {
            leftArray[i] = prices[left + i];
        }
        for (int j = 0; j < n2; j++)
        {
            rightArray[j] = prices[mid + 1 + j];
        }

        // Merge the temporary arrays back into prices[]
        int k = left; // Initial index of merged sub-array
        int iIndex = 0; // Initial index of left sub-array
        int jIndex = 0; // Initial index of right sub-array

        // Compare elements of leftArray[] and rightArray[] and place the smaller one in prices[]
        while (iIndex < n1 && jIndex < n2)
        {
            if (leftArray[iIndex] <= rightArray[jIndex])
            {
                prices[k] = leftArray[iIndex];
                iIndex++;
            }
            else
            {
                prices[k] = rightArray[jIndex];
                jIndex++;
            }
            k++;
        }

        // Copy any remaining elements of leftArray[] (if any)
        while (iIndex < n1)
        {
            prices[k] = leftArray[iIndex];
            iIndex++;
            k++;
        }

        // Copy any remaining elements of rightArray[] (if any)
        while (jIndex < n2)
        {
            prices[k] = rightArray[jIndex];
            jIndex++;
            k++;
        }
    }

    // Helper method to print the array
    public void PrintArray(int[] arr)
    {
        foreach (int price in arr)
        {
            Console.Write(price + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        MergeSort mergeSort = new MergeSort();

        // Example: Book prices
        int[] prices = { 299, 199, 399, 149, 599, 249 };

        Console.WriteLine("Book Prices before sorting:");
        mergeSort.PrintArray(prices);

        // Sort the book prices using Merge Sort
        mergeSort.SortBookPrices(prices);

        Console.WriteLine("Book Prices after sorting:");
        mergeSort.PrintArray(prices);
    }
}
