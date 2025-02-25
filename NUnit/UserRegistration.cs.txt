using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class UserRegistration
{
    public void RegisterUser(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            throw new ArgumentException("Username must be at least 3 characters long.");

        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email format.");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || 
            !Regex.IsMatch(password, @"[A-Z]") || !Regex.IsMatch(password, @"\d"))
            throw new ArgumentException("Password must be at least 8 characters long, contain one uppercase letter, and one digit.");
    }
}

[TestFixture]
public class UserRegistrationTests
{
    private UserRegistration _userRegistration;

    [SetUp]
    public void Setup()
    {
        _userRegistration = new UserRegistration();
    }

    [Test]
    public void RegisterUser_ValidInputs_ShouldNotThrowException()
    {
        Assert.DoesNotThrow(() => _userRegistration.RegisterUser("JohnDoe", "john.doe@example.com", "StrongP4ss"));
    }

    [Test]
    [TestCase("", "valid@example.com", "ValidP4ss")] // Empty username
    [TestCase("JD", "valid@example.com", "ValidP4ss")] // Too short username
    [TestCase("ValidUser", "", "ValidP4ss")] // Empty email
    [TestCase("ValidUser", "invalid-email", "ValidP4ss")] // Invalid email format
    [TestCase("ValidUser", "valid@example.com", "")] // Empty password
    [TestCase("ValidUser", "valid@example.com", "short1")] // Password too short
    [TestCase("ValidUser", "valid@example.com", "nouppercase1")] // No uppercase letter in password
    [TestCase("ValidUser", "valid@example.com", "NOLOWERCASE1")] // No lowercase letter in password
    [TestCase("ValidUser", "valid@example.com", "NoDigitHere")] // No digit in password
    public void RegisterUser_InvalidInputs_ShouldThrowArgumentException(string username, string email, string password)
    {
        Assert.Throws<ArgumentException>(() => _userRegistration.RegisterUser(username, email, password));
    }
}
