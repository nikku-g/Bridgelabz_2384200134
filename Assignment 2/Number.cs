using System;

class Number{
    static void Main(string[] args){
        // Define an integer array of 5 elements
        int[] numbers = new int[5];

        // Loop to take input for all 5 numbers
        for (int i = 0; i < numbers.Length; i++){
            Console.WriteLine("Enter number"+(i + 1)+" :");
            bool isValidInput = int.TryParse(Console.ReadLine(), out numbers[i]);

            // Check if the input is valid
            if (!isValidInput){
                Console.WriteLine("Invalid input. Please enter a valid integer.");
				// Decrease counter to ask for the number again
                i--; 
            }
        }

        // Loop through the array to check if the number is positive, negative, or zero
        for (int i = 0; i < numbers.Length; i++){
            int number = numbers[i];
            if (number > 0){
                // Check if the positive number is even or odd
                if (number % 2 == 0){
                    Console.WriteLine("Number "+(number)+"is positive and even.");
                }
                else{
                    Console.WriteLine("Number "+(number)+"is positive and odd.");
                }
            }
            else if (number < 0){
                Console.WriteLine("Number "+(number)+"is negative.");
            }
            else{
                Console.WriteLine("Number "+(number)+"is zero.");
            }
        }

        // Compare the first and last elements of the array
        int firstElement = numbers[0];
        int lastElement = numbers[numbers.Length - 1];

        if (firstElement == lastElement){
            Console.WriteLine("The first and last numbers are equal.");
        }
        else if (firstElement > lastElement){
            Console.WriteLine("The first number "+(firstElement)+"is greater than the last number "+(lastElement)+".");
        }
        else{
            Console.WriteLine("The first number "+(firstElement)+"is less than the last number "+(lastElement)+".");
        }
    }
}
