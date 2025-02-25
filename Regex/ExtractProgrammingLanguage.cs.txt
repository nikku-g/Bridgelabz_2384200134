using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";

        foreach (var lang in ExtractProgrammingLanguages(text))
        {
            Console.Write(lang + " ");
        }
    }

    static List<string> ExtractProgrammingLanguages(string text)
    {
        string[] languages = { "JavaScript", "Java", "Python", "C#", "C\\+\\+", "Ruby", "Go", "Swift", "PHP", "Kotlin", "Rust" };
        List<string> foundLanguages = new List<string>();

        foreach (var lang in languages)
        {
            string pattern = @"\b" + lang + @"\b"; // Match whole words only
            if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase))
            {
                foundLanguages.Add(lang.Replace("\\+", "+")); // Fix C++ escaping
            }
        }
        return foundLanguages;
    }
}
