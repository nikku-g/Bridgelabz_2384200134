using System;

class CustomHashMap
{
    private int[] keys;
    private int[] values;
    private bool[] occupied;
    private int size;

    public CustomHashMap(int capacity)
    {
        size = capacity * 2; // Increase size to reduce collisions
        keys = new int[size];
        values = new int[size];
        occupied = new bool[size];
    }

    private int HashFunction(int key)
    {
        return Math.Abs(key) % size;
    }

    public void Insert(int key, int value)
    {
        int index = HashFunction(key);

        // Linear probing for collision resolution
        while (occupied[index] && keys[index] != key)
        {
            index = (index + 1) % size;
        }

        keys[index] = key;
        values[index] = value;
        occupied[index] = true;
    }

    public int Get(int key)
    {
        int index = HashFunction(key);

        while (occupied[index])
        {
            if (keys[index] == key)
                return values[index];

            index = (index + 1) % size;
        }
        return -1; // Not found
    }
}

class TwoSumSolution
{
    public static int[] TwoSum(int[] arr, int target)
    {
        int n = arr.Length;
        CustomHashMap hashMap = new CustomHashMap(n);

        for (int i = 0; i < n; i++)
        {
            int complement = target - arr[i];

            // Check if complement exists
            int complementIndex = hashMap.Get(complement);
            if (complementIndex != -1)
            {
                return new int[] { complementIndex, i };
            }

            // Store the current number and its index
            hashMap.Insert(arr[i], i);
        }

        return new int[] { -1, -1 }; // No solution found
    }

    static void Main()
    {
        int[] arr = { 2, 7, 11, 15 };
        int target = 9;

        int[] result = TwoSum(arr, target);
        Console.WriteLine("Two Sum Indices: [" + result[0] + ", " + result[1] + "]");
    }
}
