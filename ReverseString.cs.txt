using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        string reversed = ReverseString(input);
        Console.WriteLine($"Reversed string: {reversed}");
    }
    
    static string ReverseString(string str)
    {
        StringBuilder sb = new StringBuilder(str);
        int length = sb.Length;
        
        for (int i = 0; i < length / 2; i++)
        {
            char temp = sb[i];
            sb[i] = sb[length - 1 - i];
            sb[length - 1 - i] = temp;
        }
        
        return sb.ToString();
    }
}