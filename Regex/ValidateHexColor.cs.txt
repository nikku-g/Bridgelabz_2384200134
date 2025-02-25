using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] hexColors = { "#FFA500", "#ff4500", "#123", "#123456", "FFA500", "#GGG999" };

        foreach (var color in hexColors)
        {
            Console.WriteLine($"'{color}' → {(IsValidHexColor(color) ? "Valid" : "Invalid")}");
        }
    }

    static bool IsValidHexColor(string color)
    {
        string pattern = @"^#([A-Fa-f0-9]{6})$";
        return Regex.IsMatch(color, pattern);
    }
}
