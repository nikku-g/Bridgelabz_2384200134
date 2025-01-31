using System;

class DateCompare
{
    static void Main()
    {
        // Prompt user for first date
        Console.Write("Enter the first date (yyyy-MM-dd): ");
        string input1 = Console.ReadLine();
        
        // Prompt user for second date
        Console.Write("Enter the second date (yyyy-MM-dd): ");
        string input2 = Console.ReadLine();

        // Try parsing the input strings to DateTime
        if (DateTime.TryParse(input1, out DateTime date1) && DateTime.TryParse(input2, out DateTime date2))
        {
            // Using DateTime.Compare()
            int result = DateTime.Compare(date1, date2);

            // Display comparison result
            if (result < 0)
                Console.WriteLine("The first date is before the second date.");
            else if (result > 0)
                Console.WriteLine("The first date is after the second date.");
            else
                Console.WriteLine("Both dates are the same.");
        }
        else
        {
            Console.WriteLine("Invalid date format! Please enter dates in yyyy-MM-dd format.");
        }

        // Wait for user input before closing
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
