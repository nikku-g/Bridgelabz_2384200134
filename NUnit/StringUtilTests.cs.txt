using System;
using NUnit.Framework;

public class StringUtils
{
    public string Reverse(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public bool IsPalindrome(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));
        string reversed = Reverse(str);
        return string.Equals(str, reversed, StringComparison.OrdinalIgnoreCase);
    }

    public string ToUpperCase(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));
        return str.ToUpper();
    }
}

[TestFixture]
public class StringUtilsTests
{
    private StringUtils _stringUtils;

    [SetUp]
    public void Setup()
    {
        _stringUtils = new StringUtils();
    }

    [Test]
    public void Reverse_ShouldReturnReversedString()
    {
        Assert.AreEqual("olleH", _stringUtils.Reverse("Hello"));
        Assert.AreEqual("!dlroW", _stringUtils.Reverse("World!"));
    }

    [Test]
    public void Reverse_NullString_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => _stringUtils.Reverse(null));
    }

    [Test]
    public void IsPalindrome_ShouldReturnTrueForPalindromes()
    {
        Assert.IsTrue(_stringUtils.IsPalindrome("madam"));
        Assert.IsTrue(_stringUtils.IsPalindrome("racecar"));
        Assert.IsTrue(_stringUtils.IsPalindrome("Able was I saw Elba")); // Case insensitive check
    }

    [Test]
    public void IsPalindrome_ShouldReturnFalseForNonPalindromes()
    {
        Assert.IsFalse(_stringUtils.IsPalindrome("hello"));
        Assert.IsFalse(_stringUtils.IsPalindrome("world"));
    }

    [Test]
    public void IsPalindrome_NullString_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => _stringUtils.IsPalindrome(null));
    }

    [Test]
    public void ToUpperCase_ShouldReturnUpperCaseString()
    {
        Assert.AreEqual("HELLO", _stringUtils.ToUpperCase("hello"));
        Assert.AreEqual("WORLD!", _stringUtils.ToUpperCase("world!"));
    }

    [Test]
    public void ToUpperCase_NullString_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => _stringUtils.ToUpperCase(null));
    }
}
