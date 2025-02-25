using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] ssnSamples = { "123-45-6789", "123456789", "987-65-4321", "000-12-3456", "123-45-678" };

        foreach (var ssn in ssnSamples)
        {
            Console.WriteLine($"'{ssn}' → {(IsValidSSN(ssn) ? "Valid" : "Invalid")}");
        }
    }

    static bool IsValidSSN(string ssn)
    {
        string pattern = @"^(?!000|666|9\d{2})\d{3}-\d{2}-\d{4}$";

        return Regex.IsMatch(ssn, pattern);
    }
}
