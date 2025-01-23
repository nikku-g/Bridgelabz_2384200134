using System;

class Tenth{
    static void Main(string[]args){
        // Initialize the total variable to store the sum
        double total = 0.0;


        // while loop asking for input until the user enters 0
        while (true){
            // prompt the user to input a number
            Console.Write("Enter a number: ");
            double number = Convert.ToDouble(Console.ReadLine());

            // Check the user entered 0 to stop the loop or not
            if (number == 0){
				// Exit the loop if the user enters 0
                break; 
            }

            // Add the number within the total
            total += number;
        }

        // Print the total sum
        Console.WriteLine("The total sum is: {0}",total);
    }
}
