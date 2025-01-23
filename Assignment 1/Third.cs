using System;

class Third{
    static void Main(string[]args){
        // Prompt the user to input three numbers
        Console.Write("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter the third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        // Check if the first number is the largest or not
        if (number1 > number2 && number1 > number3){
            Console.WriteLine("Is the first number the largest? Yes");
        }
        else{
            Console.WriteLine("Is the first number the largest? No");
        }

        // Check if the second number is the largest or not
        if (number2 > number1 && number2 > number3){
            Console.WriteLine("Is the second number the largest? Yes");
        }
        else{
            Console.WriteLine("Is the second number the largest? No");
        }

        // Check if the third number is the or not
		if (number3 > number1 && number3 > number2){
            Console.WriteLine("Is the third number the largest? Yes");
        }
        else{
            Console.WriteLine("Is the third number the largest? No");
        }
    }
}
