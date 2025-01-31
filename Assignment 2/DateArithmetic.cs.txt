using System;

class DateArithmetic
{
    static void Main()
    {
        // Prompt user to enter a date
        Console.Write("Enter a date (yyyy-MM-dd): ");
        string input = Console.ReadLine();

        // Try parsing the input string to DateTime
        if (DateTime.TryParse(input, out DateTime enteredDate))
        {
            // Add 7 days, 1 month, and 2 years
            DateTime newDate = enteredDate.AddDays(7).AddMonths(1).AddYears(2);

            // Subtract 3 weeks (3 * 7 days)
            DateTime finalDate = newDate.AddDays(-21);

            // Display results
            Console.WriteLine("\nDate Calculations:");
            Console.WriteLine($"Entered Date     : {enteredDate:yyyy-MM-dd}");
            Console.WriteLine($"After Adding: ");
            Console.WriteLine($"  - 7 Days      : {enteredDate.AddDays(7):yyyy-MM-dd}");
            Console.WriteLine($"  - 1 Month     : {enteredDate.AddDays(7).AddMonths(1):yyyy-MM-dd}");
            Console.WriteLine($"  - 2 Years     : {newDate:yyyy-MM-dd}");
            Console.WriteLine($"After Subtracting 3 Weeks: {finalDate:yyyy-MM-dd}");
        }
        else
        {
            Console.WriteLine("Invalid date format! Please enter the date in yyyy-MM-dd format.");
        }

        // Wait for user input before closing
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
