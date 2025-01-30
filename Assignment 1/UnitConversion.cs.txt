using System;

public static class UnitConverter
{
    // Method to convert kilometers to miles
    public static double ConvertKmToMiles(double km)
    {
        double km2miles = 0.621371;
        return km * km2miles;
    }

    // Method to convert miles to kilometers
    public static double ConvertMilesToKm(double miles)
    {
        double miles2km = 1.60934;
        return miles * miles2km;
    }

    // Method to convert meters to feet
    public static double ConvertMetersToFeet(double meters)
    {
        double meters2feet = 3.28084;
        return meters * meters2feet;
    }

    // Method to convert feet to meters
    public static double ConvertFeetToMeters(double feet)
    {
        double feet2meters = 0.3048;
        return feet * feet2meters;
    }
}

class UnitConversion
{
    public static void Main(string[] args)
    {
        // Test the UnitConverter methods

        // Kilometers to Miles
        double km = 10;
        Console.WriteLine("{0} kilometers is equal to {1} miles.", km, UnitConverter.ConvertKmToMiles(km).ToString("F2"));

        // Miles to Kilometers
        double miles = 6.2;
        Console.WriteLine("{0} miles is equal to {1} kilometers.", miles, UnitConverter.ConvertMilesToKm(miles).ToString("F2"));

        // Meters to Feet
        double meters = 100;
        Console.WriteLine("{0} meters is equal to {1} feet.", meters, UnitConverter.ConvertMetersToFeet(meters).ToString("F2"));

        // Feet to Meters
        double feet = 328.08;
        Console.WriteLine("{0} feet is equal to {1} meters.", feet, UnitConverter.ConvertFeetToMeters(feet).ToString("F2"));
    }
}
