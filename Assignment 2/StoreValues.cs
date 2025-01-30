using System;

class StoreValues{
    static void Main(string[] args){
        // Define an array to store up to 10 double values
        double[] numbers = new double[10];
		// Variable to store the sum of all numbers
        double total = 0.0;	
		// Variable to keep track of the current index in the array
        int index = 0; 

        // Infinite while loop to take user input until conditions are met
        while (true){
            // Prompt the user for input
            Console.WriteLine("Enter a number (0 or negative to stop):");
            double userInput;

            // Ensure valid input
            bool isValidInput = double.TryParse(Console.ReadLine(), out userInput);
            if (!isValidInput){
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            // Check if the number is 0 or negative to break the loop
            if (userInput <= 0 || index == 10){
                break; 
            }

            // Assign the number to the array and increment the index
            numbers[index] = userInput;
            index++;
        }

        // Display the numbers entered
        Console.WriteLine("\nNumbers entered:");
        for (int i = 0; i < index; i++){
            Console.WriteLine(numbers[i]);
			// Add each number to the total
            total += numbers[i]; 
        }

        // Display the total sum
        Console.WriteLine("\nTotal sum of all numbers: "+(total)+"");
    }
}
