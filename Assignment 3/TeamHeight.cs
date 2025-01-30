using System;

public class TeamHeight
{
    public static void Main(string[] args)
    {
        // Create a Random object to generate random heights
        Random random = new Random();
        
        // Array to store the heights of 11 football players
        int[] heights = new int[11];
        
        // Generate random heights for each player (between 150 and 250 cm)
        for (int i = 0; i < 11; i++)
        {
            heights[i] = random.Next(150, 250); // Random value between 150 and 250
        }

        // Display player heights
        Console.WriteLine("Player Heights (in cms):");
        foreach (int height in heights)
        {
            Console.Write(height + " "); // Print each height followed by a space
        }
        Console.WriteLine(); 

        // Calculate and display results using methods
        int sum = CalculateSum(heights);
        double mean = CalculateMean(heights);
        int shortest = FindShortest(heights);
        int tallest = FindTallest(heights);

        // Display calculated values
        Console.WriteLine($"\nSum of Heights: {sum} cm");
        Console.WriteLine($"Mean Height: {mean:F2} cm");  // Display mean with 2 decimal places
        Console.WriteLine($"Shortest Height: {shortest} cm");
        Console.WriteLine($"Tallest Height: {tallest} cm");
    }

    // Method to calculate the sum of all elements in the array
    static int CalculateSum(int[] heights)
    {
        int sum = 0;  // Variable to store the sum of heights
        foreach (int height in heights)
        {
            sum += height;  // Add each height to the sum
        }
        return sum;  // Return the total sum
    }

    // Method to calculate the average height of the players
    static double CalculateMean(int[] heights)
    {
        int sum = CalculateSum(heights);  // Get the total sum of heights
        return (double)sum / heights.Length;  // Divide sum by the number of players to get mean
    }

    // Method to find the shortest height in the array
    static int FindShortest(int[] heights)
    {
        int shortest = heights[0];  // Assume the first height is the shortest initially
        foreach (int height in heights)
        {
            if (height < shortest)  // Check if a smaller height is found
            {
                shortest = height;  // Update shortest height
            }
        }
        return shortest;  // Return the shortest height found
    }

    // Method to find the tallest height in the array
    static int FindTallest(int[] heights)
    {
        int tallest = heights[0];  // Assume the first height is the tallest initially
        foreach (int height in heights)
        {
            if (height > tallest)  // Check if a larger height is found
            {
                tallest = height;  // Update tallest height
            }
        }
        return tallest;  // Return the tallest height found
    }
}