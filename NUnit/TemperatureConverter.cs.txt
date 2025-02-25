using System;
using NUnit.Framework;

public class TemperatureConverter
{
    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}

[TestFixture]
public class TemperatureConverterTests
{
    private TemperatureConverter _converter;

    [SetUp]
    public void Setup()
    {
        _converter = new TemperatureConverter();
    }

    [Test]
    [TestCase(0, ExpectedResult = 32)]   // Freezing point of water
    [TestCase(100, ExpectedResult = 212)] // Boiling point of water
    [TestCase(-40, ExpectedResult = -40)] // -40°C is -40°F (same value)
    [TestCase(37, ExpectedResult = 98.6)] // Normal human body temperature
    public double CelsiusToFahrenheit_ShouldReturnCorrectValue(double celsius)
    {
        return _converter.CelsiusToFahrenheit(celsius);
    }

    [Test]
    [TestCase(32, ExpectedResult = 0)]   // Freezing point of water
    [TestCase(212, ExpectedResult = 100)] // Boiling point of water
    [TestCase(-40, ExpectedResult = -40)] // -40°F is -40°C (same value)
    [TestCase(98.6, ExpectedResult = 37)] // Normal human body temperature
    public double FahrenheitToCelsius_ShouldReturnCorrectValue(double fahrenheit)
    {
        return _converter.FahrenheitToCelsius(fahrenheit);
    }
}
