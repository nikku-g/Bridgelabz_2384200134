using System;
using System.Text;

class Program
{
    static void Main()
    {
        string[] strings = { "Hello", " ", "World", "!", " Welcome", " to", " C#" };
        
        string result = ConcatenateStrings(strings);
        Console.WriteLine($"Concatenated string: {result}");
    }
    
    static string ConcatenateStrings(string[] strings)
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (string str in strings)
        {
            sb.Append(str);
        }
        
        return sb.ToString();
    }
}