using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;

        // At least 8 characters, one uppercase letter, and one digit
        return password.Length >= 8 &&
               Regex.IsMatch(password, @"[A-Z]") &&
               Regex.IsMatch(password, @"\d");
    }
}

[TestFixture]
public class PasswordValidatorTests
{
    private PasswordValidator _passwordValidator;

    [SetUp]
    public void Setup()
    {
        _passwordValidator = new PasswordValidator();
    }

    [Test]
    [TestCase("StrongP4ss", ExpectedResult = true)]  // Valid password
    [TestCase("weakpass", ExpectedResult = false)]   // No uppercase, no digit
    [TestCase("SHORT1", ExpectedResult = false)]     // Too short
    [TestCase("nouppercase1", ExpectedResult = false)] // No uppercase letter
    [TestCase("NOLOWERCASE1", ExpectedResult = false)] // No lowercase letter
    [TestCase("NoDigitHere", ExpectedResult = false)] // No digit
    [TestCase("", ExpectedResult = false)] // Empty password
    [TestCase(null, ExpectedResult = false)] // Null password
    public bool IsValid_ShouldReturnCorrectResult(string password)
    {
        return _passwordValidator.IsValid(password);
    }
}
