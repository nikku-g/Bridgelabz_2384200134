using System;

class Operations
{
    static void Main()
    {
        Console.Write("enter value for a : ");
        int a = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("enter value for b : ");
        int b = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("enter value for c : ");
        int c = Convert.ToInt32(Console.ReadLine());

        int operation1 = a + b * c;  
        int operation2 = a * b + c;  
        int operation3 = c + a / b;  
        int operation4 = a % b + c;  
        // Print the results
        Console.WriteLine("The results of Int Operations are {0}, {1}, {2}, and {3}", operation1, operation2,operation3,operation4);
    }
}
