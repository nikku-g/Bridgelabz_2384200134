using System;

class Program
{
    static void Main()
    {
        int[] sortedArray = { 1, 2, 2, 2, 3, 4, 5 };
        int target = 2;
        
        int firstOccurrence = FindFirstOccurrence(sortedArray, target);
        int lastOccurrence = FindLastOccurrence(sortedArray, target);
        
        Console.WriteLine($"First occurrence of {target}: {firstOccurrence}");
        Console.WriteLine($"Last occurrence of {target}: {lastOccurrence}");
    }
    
    static int FindFirstOccurrence(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                result = mid;
                right = mid - 1;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }
    
    static int FindLastOccurrence(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                result = mid;
                left = mid + 1;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }
}