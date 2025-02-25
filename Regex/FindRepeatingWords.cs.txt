using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = "This is is a repeated repeated word test.";
        
        foreach (var word in FindRepeatingWords(input))
        {
            Console.WriteLine(word);
        }
    }

    static List<string> FindRepeatingWords(string text)
    {
        string pattern = @"\b(\w+)\s+\1\b"; // Matches consecutive repeated words
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        HashSet<string> repeatingWords = new HashSet<string>();
        foreach (Match match in matches)
        {
            repeatingWords.Add(match.Groups[1].Value); // Store unique repeated words
        }
        return new List<string>(repeatingWords);
    }
}
