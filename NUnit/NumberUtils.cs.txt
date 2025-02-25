using System;
using NUnit.Framework;

public class NumberUtils
{
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}

[TestFixture]
public class NumberUtilsTests
{
    private NumberUtils _numberUtils;

    [SetUp]
    public void Setup()
    {
        _numberUtils = new NumberUtils();
    }

    [TestCase(2, ExpectedResult = true)]
    [TestCase(4, ExpectedResult = true)]
    [TestCase(6, ExpectedResult = true)]
    [TestCase(7, ExpectedResult = false)]
    [TestCase(9, ExpectedResult = false)]
    public bool IsEven_ShouldReturnCorrectResult(int number)
    {
        return _numberUtils.IsEven(number);
    }
}
