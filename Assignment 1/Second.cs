using System;

class Second{
    static void Main(string[]args){
        // Prompt the user to input three numbers
        Console.Write("Enter the first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter the second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter the third number: ");
        int number3 = Convert.ToInt32(Console.ReadLine());

        // Check if the first number is the smallest or not
        if (number1 < number2 && number1 < number3){
            Console.WriteLine("Is the first number the smallest? Yes");
        }
        else{
            Console.WriteLine("Is the first number the smallest? No");
        }
    }
}
