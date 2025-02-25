using NUnit.Framework;
using System;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_ShouldReturnCorrectSum()
    {
        Assert.AreEqual(5, _calculator.Add(2, 3));
        Assert.AreEqual(-1, _calculator.Add(-2, 1));
    }

    [Test]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        Assert.AreEqual(1, _calculator.Subtract(3, 2));
        Assert.AreEqual(-3, _calculator.Subtract(-2, 1));
    }

    [Test]
    public void Multiply_ShouldReturnCorrectProduct()
    {
        Assert.AreEqual(6, _calculator.Multiply(2, 3));
        Assert.AreEqual(-4, _calculator.Multiply(-2, 2));
    }

    [Test]
    public void Divide_ShouldReturnCorrectQuotient()
    {
        Assert.AreEqual(2, _calculator.Divide(6, 3));
        Assert.AreEqual(-3, _calculator.Divide(-9, 3));
    }

    [Test]
    public void Divide_ByZero_ShouldThrowException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }
}
