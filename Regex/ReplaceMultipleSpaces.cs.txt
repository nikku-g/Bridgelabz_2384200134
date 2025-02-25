using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "This   is  an   example    with multiple    spaces.";
        string output = ReplaceMultipleSpaces(input);
        
        Console.WriteLine(output);
    }

    static string ReplaceMultipleSpaces(string text)
    {
        return Regex.Replace(text, @"\s+", " ");
    }
}
