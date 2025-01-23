using System;

class Sixteenth{
    static void Main(string[]args){
        Console.Write("Enter a positive integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check the number is a valid positive integer or not
        if (number <= 0){
            Console.WriteLine("Please enter a positive integer.");
        }
        else{
            // Using a for loop to iterate from 1 to the input number
            for (int i = 1; i <= number; i++){
                // Check if the number is even or odd
                if (i % 2 == 0){
                    Console.WriteLine("{0} is an even number.",i);
                }
                else{
                    Console.WriteLine("{0} is an odd number.",i);
                }
            }
        }
    }
}
