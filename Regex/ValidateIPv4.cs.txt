using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] ipAddresses = { "192.168.1.1", "255.255.255.255", "256.100.50.25", "192.168.1", "123.045.067.089" };

        foreach (var ip in ipAddresses)
        {
            Console.WriteLine($"'{ip}' → {(IsValidIPv4(ip) ? "Valid" : "Invalid")}");
        }
    }

    static bool IsValidIPv4(string ip)
    {
        string pattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)\."
                       + @"(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)\."
                       + @"(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)\."
                       + @"(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)$";

        return Regex.IsMatch(ip, pattern);
    }
}
