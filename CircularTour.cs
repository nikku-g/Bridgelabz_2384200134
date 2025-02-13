using System;

public class CircularTour
{
    // Method to find the starting pump for the circular tour
    public int FindStartPump(int[] petrol, int[] distance)
    {
        int totalSurplus = 0;  // Total surplus petrol
        int currentSurplus = 0; // Current surplus petrol
        int startPump = 0;  // Starting pump index

        int n = petrol.Length;  // Get the size of the petrol array manually

        // Traverse through all the pumps using a for loop
        for (int i = 0; i < n; i++)
        {
            totalSurplus += petrol[i] - distance[i];  // Update total surplus petrol
            currentSurplus += petrol[i] - distance[i]; // Update current surplus petrol

            // If the current surplus becomes negative, we can't start from the current pump
            if (currentSurplus < 0)
            {
                // Reset starting point to the next pump and reset current surplus
                startPump = i + 1;
                currentSurplus = 0;
            }
        }

        // If the total surplus is negative, it means it's not possible to complete the circular tour
        if (totalSurplus < 0)
        {
            return -1; // Return -1 indicating no valid starting point exists
        }

        return startPump; // Return the starting pump index
    }
}

public class Program
{
    public static void Main()
    {
        // Petrol pumps: petrol[i] is the petrol at the i-th pump
        // Distance array: distance[i] is the distance to the next pump
        int[] petrol = new int[] { 4, 6, 7, 4 };
        int[] distance = new int[] { 6, 5, 3, 5 };

        CircularTour tour = new CircularTour();
        int startPump = tour.FindStartPump(petrol, distance);

        if (startPump == -1)
        {
            Console.WriteLine("It's not possible to complete the circular tour.");
        }
        else
        {
            Console.WriteLine("Start at pump " + startPump);
        }
    }
}
