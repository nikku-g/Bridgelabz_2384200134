using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] cardNumbers = { "4111111111111111", "5105105105105100", "412345678901234", "5234567890123456", "6111111111111111" };

        foreach (var card in cardNumbers)
        {
            Console.WriteLine($"'{card}' → {ValidateCreditCard(card)}");
        }
    }

    static string ValidateCreditCard(string cardNumber)
    {
        string visaPattern = @"^4\d{15}$";  // Visa: 16 digits, starts with 4
        string masterCardPattern = @"^5\d{15}$"; // MasterCard: 16 digits, starts with 5

        if (Regex.IsMatch(cardNumber, visaPattern))
            return "Valid Visa Card";
        else if (Regex.IsMatch(cardNumber, masterCardPattern))
            return "Valid MasterCard";
        else
            return "Invalid Card";
    }
}
