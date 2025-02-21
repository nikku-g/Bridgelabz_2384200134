using System;

class Program
{
    // Method to calculate interest
    static double CalculateInterest(double amount, double rate, int years)
    {
        if (amount < 0 || rate < 0)
        {
            // Throw ArgumentException for negative values
            throw new ArgumentException("Invalid input: Amount and rate must be positive");
        }

        // Simple Interest Formula: Interest = (P × R × T) / 100
        return (amount * rate * years) / 100;
    }

    static void Main()
    {
        try
        {
            // Taking user input
            Console.WriteLine("Enter principal amount:");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter interest rate:");
            double rate = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of years:");
            int years = int.Parse(Console.ReadLine());

            // Call the method and print the calculated interest
            double interest = CalculateInterest(amount, rate, years);
            Console.WriteLine("Calculated Interest: " + interest);
        }
        catch (ArgumentException ex)
        {
            // Handle invalid input exception
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            // Handle invalid number format
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }
    }
}