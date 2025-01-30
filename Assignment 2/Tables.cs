using System;

class Tables{
    static void Main(){
        // Take user input for the base number
        Console.WriteLine("Enter a number to display the multiplication tables for numbers 6 to 9:");
        int number;
        
        // Ensure valid input
        bool isValidInput = int.TryParse(Console.ReadLine(), out number);
        
        if (!isValidInput){
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        // Define an array to store the multiplication results of 6, 7, 8, and 9
        int[] multiplicationResult = new int[4]; 

        // Loop through numbers 6 to 9 and calculate multiplication tables
        for (int i = 6; i <= 9; i++){
			// Store the result in the array
            multiplicationResult[i - 6] = number * i; 
        }

        // Display the multiplication results
        Console.WriteLine("Multiplication results:");
        for (int i = 6; i <= 9; i++){
            Console.WriteLine($"{number} * {i} = {multiplicationResult[i - 6]}");
        }
    }
}
