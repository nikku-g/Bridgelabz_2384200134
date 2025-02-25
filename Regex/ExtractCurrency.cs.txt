using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "The price is $45.99, and the discount is $ 10.50.";
        
        foreach (var currency in ExtractCurrencyValues(text))
        {
            Console.WriteLine(currency);
        }
    }

    static List<string> ExtractCurrencyValues(string text)
    {
        string pattern = @"\$\s?\d+(\.\d{2})?"; // Matches currency values with or without space after $
        MatchCollection matches = Regex.Matches(text, pattern);

        List<string> currencyValues = new List<string>();
        foreach (Match match in matches)
        {
            currencyValues.Add(match.Value.Replace(" ", "")); // Remove extra space if present
        }
        return currencyValues;
    }
}
