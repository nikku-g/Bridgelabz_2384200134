using System;

class Program
{
    static void Method1()
    {
        int num = 10;
        int divisor = 0; // Zero divisor
        int result = num / divisor; // Throws ArithmeticException at runtime
    }

    static void Method2()
    {
        Method1(); // Calls Method1(), allowing exception to propagate
    }

    static void Main()
    {
        try
        {
            Method2(); // Calls Method2(), which calls Method1()
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Handled exception in Main.");
        }
    }
}