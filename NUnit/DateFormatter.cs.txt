using System;
using NUnit.Framework;

public class DateFormatter
{
    public string FormatDate(string inputDate)
    {
        if (string.IsNullOrWhiteSpace(inputDate))
            throw new ArgumentException("Date cannot be empty or null.");

        if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            throw new FormatException("Invalid date format. Expected format: yyyy-MM-dd");

        return date.ToString("dd-MM-yyyy");
    }
}

[TestFixture]
public class DateFormatterTests
{
    private DateFormatter _formatter;

    [SetUp]
    public void Setup()
    {
        _formatter = new DateFormatter();
    }

    [Test]
    [TestCase("2024-02-22", ExpectedResult = "22-02-2024")] // Valid date
    [TestCase("2000-12-31", ExpectedResult = "31-12-2000")] // End of the year
    [TestCase("1999-01-01", ExpectedResult = "01-01-1999")] // Start of the year
    public string FormatDate_ShouldReturnFormattedDate(string inputDate)
    {
        return _formatter.FormatDate(inputDate);
    }

    [Test]
    [TestCase("22-02-2024")] // Wrong format
    [TestCase("2024/02/22")] // Wrong separator
    [TestCase("Feb 22, 2024")] // Non-numeric format
    [TestCase("2024-13-01")] // Invalid month
    [TestCase("2024-02-30")] // Invalid day
    [TestCase("")] // Empty string
    [TestCase(null)] // Null input
    public void FormatDate_InvalidInput_ShouldThrowException(string inputDate)
    {
        Assert.Throws<FormatException>(() => _formatter.FormatDate(inputDate), $"Expected format error for input: {inputDate}");
    }
}
