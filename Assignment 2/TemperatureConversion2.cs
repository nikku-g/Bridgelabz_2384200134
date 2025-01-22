using System;

class TemperatureConversion2
{
    static void Main()
    {
        Console.Write("enter temperature in Fahrenheit: ");
        double fahrenheit = Convert.ToDouble(Console.ReadLine());

        double celsiusResult = (fahrenheit - 32) * 5 / 9;

        Console.WriteLine("The {0} Fahrenheit is {1} Celsius", fahrenheit, celsiusResult);
    }
}
