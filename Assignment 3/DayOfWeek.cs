using System;

class DayOfWeek {
	public static void Main(string[] args)
    {
        // Ensure correct number of arguments
        if (args.Length != 3)
        {
            Console.WriteLine("Please provide three command-line arguments: d (day), m (month) and y (year).");
            return;
        }

        // Parse command-line arguments
        int day = int.Parse(args[0]);
        int month = int.Parse(args[1]);
        int year = int.Parse(args[2]);

        // Call DayOfWeek method to get the day of the week (in numbers)
        int dayOfWeek = formulaDayOfWeek(month, day, year);
		
		// Check if month is valid or not
		if(month > 12 || month < 0) {
			Console.WriteLine("Invalid format");
		}
		else {
			// Call DayOfWeek method to get the day of the week (in words)
			string DayOfWeek = findDayOfWeek(dayOfWeek);
			
			// Print the result
			Console.WriteLine("The day of the week for {0}/{1}/{2} is {3}.", day, month, year, DayOfWeek);
		}
		
    }

    // Method to calculate the day of the week using the provided formula
    static int formulaDayOfWeek(int month, int day, int year)
    {
        // Step 1: Apply formula for Gregorian calendar
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        int d0 = (day + x + 31 * m0 / 12) % 7;

        return d0;
    }
	
	static string findDayOfWeek(int dayOfWeek) {
		switch(dayOfWeek) {
			case 0:
				return "Sunday";
			case 1:
				return "Monday";
			case 2:
				return "Tuesday";
			case 3:
				return "Wednesday";
			case 4:
				return "Thursday";
			case 5:
				return "Friday";
			case 6:
				return "Saturday";
			default:
				return "Invalid";
		}
	}
}