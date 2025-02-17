using System;
using System.Diagnostics;

class SortingComparison
{
    static void Main()
    {
        int size = 10000; // Adjust for testing different dataset sizes
        int[] dataset = GenerateRandomArray(size);

        // Measure Bubble Sort performance
        MeasureSortTime((int[])dataset.Clone(), "BubbleSort");

        // Measure Merge Sort performance
        MeasureSortTime((int[])dataset.Clone(), "MergeSort");

        // Measure Quick Sort performance
        MeasureSortTime((int[])dataset.Clone(), "QuickSort");
    }

    // Measures execution time for sorting algorithms
    static void MeasureSortTime(int[] data, string method)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        if (method == "BubbleSort")
        {
            BubbleSort(data);
        }
        else if (method == "MergeSort")
        {
            MergeSort(data, 0, data.Length - 1);
        }
        else if (method == "QuickSort")
        {
            QuickSort(data, 0, data.Length - 1);
        }

        stopwatch.Stop();
        Console.WriteLine($"{method} Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Generates a random array
    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, size);
        }
        return arr;
    }

    // Bubble Sort (O(N²))
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Merge Sort (O(N log N))
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int i1 = 0, i2 = 0, k = left;
        while (i1 < n1 && i2 < n2)
        {
            if (L[i1] <= R[i2])
                arr[k++] = L[i1++];
            else
                arr[k++] = R[i2++];
        }

        while (i1 < n1)
            arr[k++] = L[i1++];
        while (i2 < n2)
            arr[k++] = R[i2++];
    }

    // Quick Sort (O(N log N))
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;
        return i + 1;
    }
}
