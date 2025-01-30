using System;

class Calender
{
    // Array for month names
    static string[] monthNames = { "January", "February", "March", "April", "May", "June", 
                                   "July", "August", "September", "October", "November", "December" };

    // Array for the number of days in each month
    static int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    static void Main()
    {
        // Take user input for month and year
        Console.WriteLine("Enter the month (1-12): ");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the year: ");
        int year = int.Parse(Console.ReadLine());

        // Check if the year is a leap year and adjust February days
        if (IsLeapYear(year))
        {
            daysInMonth[1] = 29; // February has 29 days in a leap year
        }
        
        // Display the calendar header
        Console.WriteLine("\n" + monthNames[month - 1] + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        // Get the first day of the month (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
        int firstDay = GetFirstDayOfMonth(month, year);

        // Print leading spaces for the first day of the month
        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("    ");  // 4 spaces for each empty day
        }

        // Print the days of the month
        int daysInCurrentMonth = daysInMonth[month - 1];
        for (int day = 1; day <= daysInCurrentMonth; day++)
        {
            Console.Write("{0,3} ",day);  // Print each day with a width of 3 characters for alignment

            // If the day is Saturday, move to the next line
            if ((firstDay + day) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine(); // Print a new line at the end for formatting
    }

    // Method to check if a given year is a leap year
    static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    // Method to get the first day of the month (using the Gregorian calendar algorithm)
    static int GetFirstDayOfMonth(int month, int year)
    {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        int d0 = (1 + x + 31 * m0 / 12) % 7; // Day of the week for the first day of the month

        return d0;  // Return the day of the week (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
    }
}
