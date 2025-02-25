using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] plateNumbers = { "AB1234", "A12345", "XY9876", "ZZ12", "1234AB", "CD567" };

        foreach (var plate in plateNumbers)
        {
            Console.WriteLine($"'{plate}' → {(IsValidLicensePlate(plate) ? "Valid" : "Invalid")}");
        }
    }

    static bool IsValidLicensePlate(string plate)
    {
        string pattern = @"^[A-Z]{2}\d{4}$";
        return Regex.IsMatch(plate, pattern);
    }
}
