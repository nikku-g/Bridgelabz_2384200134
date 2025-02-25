using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020.";
        
        foreach (var date in ExtractDates(text))
        {
            Console.WriteLine(date);
        }
    }

    static List<string> ExtractDates(string text)
    {
        string pattern = @"\b(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        List<string> dates = new List<string>();
        foreach (Match match in matches)
        {
            dates.Add(match.Value);
        }
        return dates;
    }
}
