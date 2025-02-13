using System;

public class PairWithGivenSum
{
    // Method to check if a pair exists with the given sum
    public bool HasPairWithSum(int[] arr, int target)
    {
        // Create an array to simulate a hash map (for simplicity, we'll use a fixed size array)
        bool[] seen = new bool[10000]; // Assuming the range of values in arr is within a certain range (e.g., [-10000, 10000])
        
        int n = 0;
        // Find the length of the array manually
        while (true)
        {
            try
            {
                int temp = arr[n];  // Try accessing element at index n
                n++;  // If successful, increment n
            }
            catch (IndexOutOfRangeException)  // If an exception occurs, we reached the end of the array
            {
                break;
            }
        }

        // Traverse the array
        for (int i = 0; i < n; i++)
        {
            int complement = target - arr[i];

            // If the complement exists in the seen array, we've found a pair
            if (complement >= 0 && complement < 10000 && seen[complement])
            {
                return true;
            }

            // Mark the current element as seen
            if (arr[i] >= 0 && arr[i] < 10000)
            {
                seen[arr[i]] = true;
            }
        }

        // No pair found
        return false;
    }
}

public class Program
{
    public static void Main()
    {
        PairWithGivenSum pairFinder = new PairWithGivenSum();

        // Example array and target sum
        int[] arr = { 10, 15, 3, 7, 8, 2 };
        int target = 17;

        // Check if there's a pair with the given sum
        bool result = pairFinder.HasPairWithSum(arr, target);

        if (result)
        {
            Console.WriteLine("Pair with the given sum exists.");
        }
        else
        {
            Console.WriteLine("No pair with the given sum exists.");
        }
    }
}
