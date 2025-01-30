using System;

class UnitConverter
{
    // Method to convert Fahrenheit to Celsius
    public static double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        double fahrenheit2celsius = (fahrenheit - 32) * 5 / 9;
        return fahrenheit2celsius;
    }

    // Method to convert Celsius to Fahrenheit
    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        double celsius2fahrenheit = (celsius * 9 / 5) + 32;
        return celsius2fahrenheit;
    }

    // Method to convert pounds to kilograms
    public static double ConvertPoundsToKilograms(double pounds)
    {
        double pounds2kilograms = 0.453592;
        return pounds * pounds2kilograms;
    }

    // Method to convert kilograms to pounds
    public static double ConvertKilogramsToPounds(double kilograms)
    {
        double kilograms2pounds = 2.20462;
        return kilograms * kilograms2pounds;
    }

    // Method to convert gallons to liters
    public static double ConvertGallonsToLiters(double gallons)
    {
        double gallons2liters = 3.78541;
        return gallons * gallons2liters;
    }

    // Method to convert liters to gallons
    public static double ConvertLitersToGallons(double liters)
    {
        double liters2gallons = 0.264172;
        return liters * liters2gallons;
    }
}

class UnitConversion3
{
    public static void Main(string[] args)
    {
        // Example usage
        Console.WriteLine("100 Fahrenheit to Celsius: " + UnitConverter.ConvertFahrenheitToCelsius(100).ToString("F2"));
        Console.WriteLine("37 Celsius to Fahrenheit: " + UnitConverter.ConvertCelsiusToFahrenheit(37).ToString("F2"));
        Console.WriteLine("150 pounds to kilograms: " + UnitConverter.ConvertPoundsToKilograms(150).ToString("F2"));
        Console.WriteLine("70 kilograms to pounds: " + UnitConverter.ConvertKilogramsToPounds(70).ToString("F2"));
        Console.WriteLine("10 gallons to liters: " + UnitConverter.ConvertGallonsToLiters(10).ToString("F2"));
        Console.WriteLine("20 liters to gallons: " + UnitConverter.ConvertLitersToGallons(20).ToString("F2"));
    }
}
