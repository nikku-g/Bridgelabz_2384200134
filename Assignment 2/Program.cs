using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the 1st number : ");
        int number1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter the 2nd number : ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        int quotient = number1 / number2;
        int remainder = number1 % number2;

        Console.WriteLine("The Quotient is {0} and Remainder is {1} of two numbers {2} and {3}", quotient, remainder, number1, number2);
    }
}
