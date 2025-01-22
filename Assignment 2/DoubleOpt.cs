using System;

class DoubleOpt
{
    static void Main()
    {
        Console.Write("Enter value for a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter value for b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter value for c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double operation1 = a + b * c;  
        double operation2 = a * b + c;  
        double operation3 = c + a / b;  
        double operation4 = a % b + c;  

        Console.WriteLine("The results of Double Operations are {0}, {1}, {2}, and {3}", operation1, operation2, operation3, operation4);
    }
}
