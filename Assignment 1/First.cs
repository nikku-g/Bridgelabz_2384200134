using System;

class First{
    static void Main(string[]args){
        // Prompt the user to input a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        // Check the number is divisible by 5 or not
        if (number % 5 == 0){
            Console.WriteLine("Is the number {0} divisible by 5? Yes",number);
        }
        else{
            Console.WriteLine($"Is the number {0} divisible by 5? No",number);
        }
    }
}
