using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "Visit https://www.google.com and http://example.org for more info. Also check https://github.com/user/repo.";

        foreach (var link in ExtractLinks(text))
        {
            Console.WriteLine(link);
        }
    }

    static List<string> ExtractLinks(string text)
    {
        string pattern = @"\bhttps?://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(/\S*)?\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        List<string> links = new List<string>();
        foreach (Match match in matches)
        {
            links.Add(match.Value);
        }
        return links;
    }
}
