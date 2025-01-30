using System;

class UnitConverter
{
    // Method to convert yards to feet
    public static double ConvertYardsToFeet(double yards)
    {
        double yards2feet = 3;
        return yards * yards2feet;
    }

    // Method to convert feet to yards
    public static double ConvertFeetToYards(double feet)
    {
        double feet2yards = 0.333333;
        return feet * feet2yards;
    }

    // Method to convert meters to inches
    public static double ConvertMetersToInches(double meters)
    {
        double meters2inches = 39.3701;
        return meters * meters2inches;
    }

    // Method to convert inches to meters
    public static double ConvertInchesToMeters(double inches)
    {
        double inches2meters = 0.0254;
        return inches * inches2meters;
    }

    // Method to convert inches to centimeters
    public static double ConvertInchesToCentimeters(double inches)
    {
        double inches2cm = 2.54;
        return inches * inches2cm;
    }
}

class UnitConversion2
{
    public static void Main(string[] args)
    {
        // Example usage
        Console.WriteLine("10 yards to feet: " + UnitConverter.ConvertYardsToFeet(10));
        Console.WriteLine("30 feet to yards: " + UnitConverter.ConvertFeetToYards(30));
        Console.WriteLine("5 meters to inches: " + UnitConverter.ConvertMetersToInches(5));
        Console.WriteLine("50 inches to meters: " + UnitConverter.ConvertInchesToMeters(50));
        Console.WriteLine("20 inches to centimeters: " + UnitConverter.ConvertInchesToCentimeters(20));
    }
}
