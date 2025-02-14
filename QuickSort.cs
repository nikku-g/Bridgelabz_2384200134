using System;

public class QuickSort
{
    // Method to implement Quick Sort
    public void SortProductPrices(int[] prices)
    {
        // Call the Quick Sort function on the entire array
        QuickSortArray(prices, 0, prices.Length - 1);
    }

    // Helper method to perform quick sort recursively
    private void QuickSortArray(int[] prices, int low, int high)
    {
        if (low < high)
        {
            // Find the pivot element such that the element is placed at the correct position
            int pivot = Partition(prices, low, high);

            // Recursively apply Quick Sort on the left and right partitions
            QuickSortArray(prices, low, pivot - 1);  // Left partition
            QuickSortArray(prices, pivot + 1, high); // Right partition
        }
    }

    // Method to partition the array around the pivot element
    private int Partition(int[] prices, int low, int high)
    {
        // Pick the last element as the pivot
        int pivot = prices[high];
        
        // Pointer for the smaller element
        int i = (low - 1); 

        // Traverse through the array and partition
        for (int j = low; j < high; j++)
        {
            // If the current element is smaller than the pivot, swap it with the element at i
            if (prices[j] < pivot)
            {
                i++;
                Swap(prices, i, j); // Swap elements at i and j
            }
        }

        // Swap the pivot element with the element at i+1
        Swap(prices, i + 1, high);

        return i + 1; // Return the partition index
    }

    // Method to swap two elements in the array
    private void Swap(int[] prices, int i, int j)
    {
        int temp = prices[i];
        prices[i] = prices[j];
        prices[j] = temp;
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
        QuickSort quickSort = new QuickSort();

        // Example: Product prices
        int[] prices = { 450, 220, 870, 510, 600, 420, 340 };

        Console.WriteLine("Product Prices before sorting:");
        quickSort.PrintArray(prices);

        // Sort the product prices using Quick Sort
        quickSort.SortProductPrices(prices);

        Console.WriteLine("Product Prices after sorting:");
        quickSort.PrintArray(prices);
    }
}
