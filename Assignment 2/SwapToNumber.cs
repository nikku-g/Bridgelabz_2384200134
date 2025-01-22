using System;

class SwapToNumber
{
    static void Main()
    {
        Console.Write("enter the first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("enter the second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        int swap = number1;
        number1 = number2;
        number2 = swap;

        Console.WriteLine("The swapped numbers are {0} and {1}", number1, number2);
    }
}
