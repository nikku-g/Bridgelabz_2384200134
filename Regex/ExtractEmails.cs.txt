using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "Contact us at support@example.com and info@company.org. Also, reach out at help123@service.net!";
        
        foreach (var email in ExtractEmails(text))
        {
            Console.WriteLine(email);
        }
    }

    static string[] ExtractEmails(string text)
    {
        string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
        MatchCollection matches = Regex.Matches(text, pattern);

        string[] emails = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            emails[i] = matches[i].Value;
        }
        return emails;
    }
}
