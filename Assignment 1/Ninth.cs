using System;

class Ninth{
    static void Main(string[]args){
        // prompt the user to input a starting value for the countdown
        Console.Write("Enter a number for starting the countdown: ");
        int counter = Convert.ToInt32(Console.ReadLine());

        // Use a for loop for count down
        for (int i = counter; i >= 1; i--){
            Console.WriteLine(i); 
        }

        // When the countdown reaches 1
        Console.WriteLine("Launch");
    }
}
