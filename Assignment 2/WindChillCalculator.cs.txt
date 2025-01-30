using System;

public class WindChillCalculator
{
    public static void Main(string[] args)
    {
		// Taking user input to enter the temperature in fahrenheit
        Console.Write("Enter the temperature in Fahrenheit: ");
        double temperature = Convert.ToDouble(Console.ReadLine());

        // Taking user input to enter the wind speed in mph
        Console.Write("Enter the wind speed in mph: ");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        // Ensure wind speed is not negative
        if (windSpeed < 0)
        {
            Console.WriteLine("Error: Wind speed cannot be negative.");
            return;
        }

        double windChill = CalculateWindChill(temperature, windSpeed);

        Console.WriteLine("\nThe wind chill temperature is: {0} °F", windChill.ToString("F2"));
    }

    // Method to calculate the wind chill using the given formula
    public static double CalculateWindChill(double temperature, double windSpeed)
    {
        double windChill = 35.74 + 0.6215 * temperature + (0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16);
        return windChill;
    }
}