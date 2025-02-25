using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] testUsernames = { "user_123", "123user", "us" };

        foreach (string username in testUsernames)
        {
            Console.WriteLine($"\"{username}\" → {(IsValidUsername(username) ? "Valid" : "Invalid")}");
        }
    }

    static bool IsValidUsername(string username)
    {
        // Regex breakdown:
        // ^            : Start of string
        // [A-Za-z]     : First character must be a letter
        // [A-Za-z0-9_]{4,14} : Followed by 4 to 14 characters that can be letters, numbers, or underscores
        // $            : End of string
        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";
        return Regex.IsMatch(username, pattern);
    }
}
