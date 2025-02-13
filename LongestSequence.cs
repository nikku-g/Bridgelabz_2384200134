using System;

class CustomHashSet
{
    private int[] table;
    private bool[] occupied;
    private int capacity;

    public CustomHashSet(int size)
    {
        capacity = size * 2; // Increase size to reduce collisions
        table = new int[capacity];
        occupied = new bool[capacity];
    }

    private int HashFunction(int key)
    {
        return Math.Abs(key) % capacity;
    }

    public void Insert(int key)
    {
        int index = HashFunction(key);

        // Linear probing to resolve collisions
        while (occupied[index] && table[index] != key)
        {
            index = (index + 1) % capacity;
        }

        if (!occupied[index])
        {
            table[index] = key;
            occupied[index] = true;
        }
    }

    public bool Contains(int key)
    {
        int index = HashFunction(key);
        while (occupied[index])
        {
            if (table[index] == key)
                return true;

            index = (index + 1) % capacity;
        }
        return false;
    }
}

class LongestConsecutiveSequence
{
    public static int FindLongestConsecutive(int[] arr)
    {
        int n = arr.Length;
        if (n == 0) return 0;

        // Insert all elements into our custom hash set
        CustomHashSet hashSet = new CustomHashSet(n);
        foreach (int num in arr)
            hashSet.Insert(num);

        int longestStreak = 0;

        // Find the longest consecutive sequence
        foreach (int num in arr)
        {
            // Check if this is a sequence start (num - 1 should not exist)
            if (!hashSet.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;

                // Count the length of the sequence
                while (hashSet.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }

    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2, 5, 6, 7 };
        int result = FindLongestConsecutive(arr);
        Console.WriteLine("Length of Longest Consecutive Sequence: " + result);
    }
}
