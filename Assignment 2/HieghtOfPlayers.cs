using System;

class HieghtOf Players{
    static void Main(string[] args){
        // Define an array to store the heights of 11 players
        double[] heights = new double[11];
		// Variable to store the sum of heights
        double sum = 0.0; 

        // Loop to get the height of each player from the user
        for (int i = 0; i < heights.Length; i++){
            Console.WriteLine("Enter the height of player "+(i + 1)+" (in meters):");
            bool isValidInput = double.TryParse(Console.ReadLine(), out heights[i]);

            // Check if the input is a valid number
            if (!isValidInput || heights[i] <= 0){
                Console.WriteLine("Invalid input. Please enter a positive number.");
                i--; 
            }
        }

        // Calculate the sum of all heights
        foreach (double height in heights){
            sum += height;
        }

        // Calculate the mean height
        double meanHeight = sum / heights.Length;

        // Display the mean height of the football team
        Console.WriteLine("\nThe mean height of the football team is: "+(meanHeight:F2)+" meters.");
    }
}
