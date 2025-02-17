using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string[] strings = { "Hello", " ", "World", "!", " Welcome", " to", " C#" };
        
        Stopwatch sw = new Stopwatch();
        
        sw.Start();
        string result1 = ConcatenateStrings(strings);
        sw.Stop();
        Console.WriteLine($"Concatenated string using StringBuilder: {result1}");
        Console.WriteLine($"Time taken using StringBuilder: {sw.ElapsedMilliseconds} ms");
        
        sw.Restart();
        string result2 = ConcatenateStringsUsingString(strings);
        sw.Stop();
        Console.WriteLine($"Concatenated string using string: {result2}");
        Console.WriteLine($"Time taken using string concatenation: {sw.ElapsedMilliseconds} ms");
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
    
    static string ConcatenateStringsUsingString(string[] strings)
    {
        string result = "";
        
        foreach (string str in strings)
        {
            result += str;
        }
        
        return result;
    }
}