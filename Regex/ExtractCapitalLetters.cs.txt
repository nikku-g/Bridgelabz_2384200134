using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";

        foreach (var word in ExtractCapitalizedWords(text))
        {
            Console.Write(word + " ");
        }
    }

    static List<string> ExtractCapitalizedWords(string text)
    {
        string pattern = @"\b[A-Z][a-z]*\b"; // Matches words that start with an uppercase letter
        MatchCollection matches = Regex.Matches(text, pattern);

        List<string> capitalizedWords = new List<string>();
        foreach (Match match in matches)
        {
            capitalizedWords.Add(match.Value);
        }
        return capitalizedWords;
    }
}
