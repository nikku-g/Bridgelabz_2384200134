using System;

class Eighth{
    static void Main(string[]args){
        // Prompt the user to input a starting value for the countdown
        Console.Write("Enter a number for starting the countdown: ");
        int counter = Convert.ToInt32(Console.ReadLine());

        // The countdown using a while loop
        while (counter >= 1){
            Console.WriteLine(counter);
            counter--;
        }

        // When the countdown reaches 1
        Console.WriteLine("Launch");
    }
}
