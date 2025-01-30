using System;

class Factorial{
    static void Main(string[] agrs){
        // Take the input number
        Console.WriteLine("Enter a number to find its factors:");
        int number;
        
        // Validate the input using TryParse
        bool isValidInput = int.TryParse(Console.ReadLine(), out number);
        if (!isValidInput || number <= 0){
            Console.WriteLine("Please enter a valid positive integer.");
            return;
        }

        // Initialize variables
        int maxFactor = 10;  
		// Array to store factors
        int[] factors = new int[maxFactor];  
        int index = 0;  
		
        // Loop through numbers from 1 to the number to find factors
        for (int i = 1; i <= number; i++){
			// Check if 'i' is a factor of 'number'
            if (number % i == 0){
                // If the array is full, resize it
                if (index == maxFactor){
                    // Double the array size
                    maxFactor *= 2;
                    int[] temp = new int[maxFactor];
					// Copy existing factors into the new array
                    factors.CopyTo(temp, 0);
					// Assign the resized array back to factors
                    factors = temp;  
                }
                // Add the factor to the array
                factors[index] = i;
                index++; 
            }
        }

        // Display the factors
        Console.WriteLine("The factors of {0} are:",number);
        for (int i = 0; i < index; i++)
        {
            Console.Write(factors[i] + " ");
        }
    }
}
