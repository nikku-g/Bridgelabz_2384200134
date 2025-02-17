using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        string result = RemoveDuplicates(input);
        Console.WriteLine($"String after removing duplicates: {result}");
    }
    
    static string RemoveDuplicates(string str)
    {
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < str.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < sb.Length; j++)
            {
                if (sb[j] == str[i])
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                sb.Append(str[i]);
            }
        }
        return sb.ToString();
    }
}