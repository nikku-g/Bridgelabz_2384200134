using System;

class TemperatureConversion
{
    static void Main()
    {
        Console.Write("enter temperature in Celsius : ");
        double celsius = Convert.ToDouble(Console.ReadLine());

        double fahrenheitResult = (celsius * 9 / 5) + 32;

        Console.WriteLine("The {0} Celsius is {1} Fahrenheit", celsius, fahrenheitResult);
    }
}
