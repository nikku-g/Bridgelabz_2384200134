using System;

class Fifteenth{
    static void Main(string[]args){
        Console.Write("Enter a positive integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is a natural number
        if (number < 0){
            Console.WriteLine("Please enter a natural number.");
        }
        else{
            int factorial = 1;

            // Compute factorial using a for loop
            for (int i=1;i<= number;i++){
				
				// Multiply the numbers to find factorial
                factorial *= i; 
            }

            // Print the result
            Console.WriteLine("The factorial of {0} is: {1}",number, factorial);
        }
    }
}
