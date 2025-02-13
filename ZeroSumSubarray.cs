using System;
using System.Collections.Generic;

class CustomHashMap
{
    private int[] keys;
    private int[][] values;
    private int size;

    public CustomHashMap(int capacity)
    {
        keys = new int[capacity];
        values = new int[capacity][];
        size = 0;
    }

    private int HashFunction(int key)
    {
        return Math.Abs(key) % keys.Length;
    }

    public void Insert(int key, int value)
    {
        int index = HashFunction(key);

        // Linear probing for collision resolution
        while (keys[index] != 0 && keys[index] != key)
        {
            index = (index + 1) % keys.Length;
        }

        keys[index] = key;

        // Store multiple indices
        if (values[index] == null)
        {
            values[index] = new int[] { value };
        }
        else
        {
            Array.Resize(ref values[index], values[index].Length + 1);
            values[index][values[index].Length - 1] = value;
        }
    }

    public int[] Get(int key)
    {
        int index = HashFunction(key);
        while (keys[index] != 0)
        {
            if (keys[index] == key)
                return values[index];

            index = (index + 1) % keys.Length;
        }
        return null;
    }
}

class ZeroSumSubarrays
{
    public static void FindZeroSumSubarrays(int[] arr)
    {
        int n = arr.Length;
        int cumulativeSum = 0;
        CustomHashMap hashMap = new CustomHashMap(2 * n);
        
        Console.WriteLine("Zero-sum subarrays:");

        for (int i = 0; i < n; i++)
        {
            cumulativeSum += arr[i];

            // If cumulative sum is zero, subarray from 0 to i is valid
            if (cumulativeSum == 0)
            {
                Console.WriteLine($"Subarray found from index 0 to {i}");
            }

            // If cumulative sum has been seen before, zero-sum subarrays exist
            int[] previousIndices = hashMap.Get(cumulativeSum);
            if (previousIndices != null)
            {
                foreach (int startIdx in previousIndices)
                {
                    Console.WriteLine($"Subarray found from index {startIdx + 1} to {i}");
                }
            }

            // Store cumulative sum index
            hashMap.Insert(cumulativeSum, i);
        }
    }

    static void Main()
    {
        int[] arr = { 4, 2, -3, 1, 6, -4, -2, 3, 2, -3 };
        FindZeroSumSubarrays(arr);
    }
}
