using System;

class Multiplication{
    static void Main(string[] args){
        // Get the number from the user
        Console.WriteLine("Enter a number to print its multiplication table:");
        int number;
        
        // Ensure valid input
        bool isValidInput = int.TryParse(Console.ReadLine(), out number);
        
        if (!isValidInput){
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        // Define an integer array to store multiplication results
        int[] multiplicationTable = new int[10];

        // Run a loop from 1 to 10 and store the multiplication results in the array
        for (int i = 1; i <= 10; i++){
            multiplicationTable[i - 1] = number * i;
        }

        // Display the multiplication table
        Console.WriteLine("Multiplication table of "+(number)+":");
        for (int i = 0; i < multiplicationTable.Length; i++){
            Console.WriteLine(""+(number)+" * "+(i + 1)+" = "+(multiplicationTable[i])+"");
        }
    }
}
