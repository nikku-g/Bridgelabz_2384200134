using System;

class YoungAndTall
{
    public static void Main()
    {
        // Arrays to store age and height of the friends
        int[] ages = new int[3];
        double[] heights = new double[3];
        string[] names = { "Amar", "Akbar", "Anthony" };

        // Input ages and heights for each friend
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter details for {0}:", names[i]);
            Console.WriteLine("Enter age of {0}: ", names[i]);
			ages[i] = Convert.ToInt32(Console.ReadLine());
			if (ages[i] < 0 || ages[i] > 100) {
				Console.Error.WriteLine("Invalid input. Please enter a number between 0 and 100.");
				Environment.Exit(0);
			}
            Console.WriteLine("Enter height (in cm) of {0}: ", names[i]);
			heights[i] = Convert.ToDouble(Console.ReadLine());
			if (heights[i] < 0 || heights[i] > 300) {
				Console.Error.WriteLine("Invalid input. Please enter a number between 0 and 300.");
				Environment.Exit(0);
			}
        }

        // Find the youngest friend
        int youngestIndex = FindYoungest(ages);

        // Find the tallest friend
        int tallestIndex = FindTallest(heights);

        // Display results
        Console.WriteLine("\nResults:");
        Console.WriteLine("The youngest friend is {0} with an age of {1} years.", names[youngestIndex], ages[youngestIndex]);
        Console.WriteLine("The tallest friend is {0} with a height of {1} cm.", names[tallestIndex], heights[tallestIndex]);
    }

    // Method to find the youngest friend
    static int FindYoungest(int[] ages)
    {
        int minAge = ages[0];
        int youngestIndex = 0;

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < minAge)
            {
                minAge = ages[i];
                youngestIndex = i;
            }
        }

        return youngestIndex;
    }

    // Method to find the tallest friend
    static int FindTallest(double[] heights)
    {
        double maxHeight = heights[0];
        int tallestIndex = 0;

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > maxHeight)
            {
                maxHeight = heights[i];
                tallestIndex = i;
            }
        }

        return tallestIndex;
    }
}
