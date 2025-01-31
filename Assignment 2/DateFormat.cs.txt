using System;
using System.Globalization;

class DateFormat
{
    static void Main()
    {
        // Get the current date
        DateTime currentDate = DateTime.Now;

        // Display the date in different formats
        Console.WriteLine("Current Date in Different Formats:");
        Console.WriteLine($"1. dd/MM/yyyy     : {currentDate.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"2. yyyy-MM-dd     : {currentDate.ToString("yyyy-MM-dd")}");
        Console.WriteLine($"3. EEE, MMM dd, yyyy : {currentDate.ToString("ddd, MMM dd, yyyy", CultureInfo.InvariantCulture)}");

        // Wait for user input before closing
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
