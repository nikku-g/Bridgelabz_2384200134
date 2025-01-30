using System;

public class FriendComparison
{
    // Method to find the youngest friend's index
    public int FindYoungestIndex(int[] ages)
    {
        int youngestIndex = 0;
        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[youngestIndex])
            {
                youngestIndex = i;
            }
        }
        return youngestIndex;
    }

    // Method to find the tallest friend's index
    public int FindTallestIndex(float[] heights)
    {
        int tallestIndex = 0;
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[tallestIndex])
            {
                tallestIndex = i;
            }
        }
        return tallestIndex;
    }
}

class TallestFriend
{
    public static void Main(string[] args)
    {
        string[] friends = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        float[] heights = new float[3];
        FriendComparison comparison = new FriendComparison();

        Console.WriteLine("Enter the age and height for Amar, Akbar, and Anthony:");

        for (int i = 0; i < friends.Length; i++)
        {
            Console.Write("{0}'s Age: ", friends[i]);
            while (!int.TryParse(Console.ReadLine(), out ages[i]))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for age.");
                Console.Write("{0}'s Age: ", friends[i]);
            }

            Console.Write("{0}'s Height (in cm): ", friends[i]);
            while (!float.TryParse(Console.ReadLine(), out heights[i]))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for height.");
                Console.Write("{0}'s Height (in cm): ", friends[i]);
            }
        }

        // Find the youngest friend
        int youngestIndex = comparison.FindYoungestIndex(ages);
        Console.WriteLine("\nThe youngest friend is {0} with age {1}.", friends[youngestIndex], ages[youngestIndex]);

        // Find the tallest friend
        int tallestIndex = comparison.FindTallestIndex(heights);
        Console.WriteLine("The tallest friend is {0} with height {1} cm.", friends[tallestIndex], heights[tallestIndex]);
    }
}
