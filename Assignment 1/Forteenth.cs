using System;

class Forteenth{
    static void Main(string[]args){
        Console.Write("Enter a positive integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is a positive integer
        if (number < 0){
            Console.WriteLine("Please enter a positive integer.");
        }
        else{
            int factorial = 1;
            int i = 1;

            // Compute factorial using a while loop
            while (i <= number){
				// Multiply the numbers to find factorial
                factorial *= i;  
                i++; 
            }

            // Print the result
            Console.WriteLine("The factorial of {0} is: {1}",number, factorial);
        }
    }
}
