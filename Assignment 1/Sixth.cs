using System;

class Sixth{
    static void Main(string[]args){
        // Prompt the user to input a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check the number is positive, negative, or zero
        if (number > 0){
            Console.WriteLine("Positive");
        }
        else if (number < 0){
            Console.WriteLine("Negative");
        }
        else{
            Console.WriteLine("Zero");
        }
    }
}
