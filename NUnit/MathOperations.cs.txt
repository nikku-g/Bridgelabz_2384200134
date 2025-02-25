using System;
using NUnit.Framework;

public class MathOperations
{
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new ArithmeticException("Division by zero is not allowed.");
        return a / b;
    }
}

[TestFixture]
public class MathOperationsTests
{
    private MathOperations _mathOperations;

    [SetUp]
    public void Setup()
    {
        _mathOperations = new MathOperations();
    }

    [Test]
    public void Divide_ByZero_ShouldThrowArithmeticException()
    {
        Assert.Throws<ArithmeticException>(() => _mathOperations.Divide(10, 0));
    }

    [Test]
    public void Divide_ValidInputs_ShouldReturnCorrectQuotient()
    {
        Assert.AreEqual(2, _mathOperations.Divide(10, 5));
        Assert.AreEqual(-3, _mathOperations.Divide(-9, 3));
    }
}
