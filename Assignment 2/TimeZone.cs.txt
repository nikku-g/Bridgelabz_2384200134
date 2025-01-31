using System;

class TimeZone
{
    static void Main()
    {
        // Get the current UTC time
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        
        // Define time zones
        TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        // Convert UTC to different time zones
        DateTimeOffset gmtTime = TimeZoneInfo.ConvertTime(utcNow, gmtZone);
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcNow, istZone);
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcNow, pstZone);

        // Display results
        Console.WriteLine("Current Time in Different Time Zones:");
        Console.WriteLine("GMT: {0}", gmtTime);
        Console.WriteLine("IST: {0}", istTime);
        Console.WriteLine("PST: {0}", pstTime);

        // Wait for user input to exit
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
