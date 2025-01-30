using System;

class LeapYear
{
    public static void Main(string[] args)
    {
        // Take user input for the year
        Console.Write("Enter a year (>= 1582): ");
		int year = Convert.ToInt32(Console.ReadLine());
		if(year < 1582) {
			Console.WriteLine("Invalid input! Please enter a year greater than or equal to 1582.");
            return;
		}

        // Check if the year is a leap year
        bool isLeapYear = CheckLeapYear(year);

        // Output the result
        if (isLeapYear)
        {
            Console.WriteLine("The year {0} is a Leap Year.", year);
        }
        else
        {
            Console.WriteLine("The year {0} is not a Leap Year.", year);
        }
    }

    // Method to check if a year is a leap year
    static bool CheckLeapYear(int year)
    {
        // Leap year conditions: divisible by 4 and not divisible by 100, or divisible by 400
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
