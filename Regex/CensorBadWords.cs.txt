using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "This is a damn bad example with some stupid words.";
        string[] badWords = { "damn", "stupid" }; // List of bad words

        string output = CensorBadWords(input, badWords);
        Console.WriteLine(output);
    }

    static string CensorBadWords(string text, string[] badWords)
    {
        foreach (var word in badWords)
        {
            string pattern = @"\b" + Regex.Escape(word) + @"\b"; // Match whole words only
            text = Regex.Replace(text, pattern, "****", RegexOptions.IgnoreCase);
        }
        return text;
    }
}
