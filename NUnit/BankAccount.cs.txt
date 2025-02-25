using System;
using NUnit.Framework;

public class BankAccount
{
    private double _balance;

    public BankAccount(double initialBalance = 0)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");
        _balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");
        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
    }

    public double GetBalance()
    {
        return _balance;
    }
}

[TestFixture]
public class BankAccountTests
{
    private BankAccount _account;

    [SetUp]
    public void Setup()
    {
        _account = new BankAccount(100); // Initial balance = 100
    }

    [Test]
    public void Deposit_ShouldIncreaseBalance()
    {
        _account.Deposit(50);
        Assert.AreEqual(150, _account.GetBalance(), "Balance should increase after deposit.");
    }

    [Test]
    public void Withdraw_ShouldDecreaseBalance()
    {
        _account.Withdraw(30);
        Assert.AreEqual(70, _account.GetBalance(), "Balance should decrease after withdrawal.");
    }

    [Test]
    public void Withdraw_MoreThanBalance_ShouldThrowException()
    {
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(200), "Withdrawal should fail if funds are insufficient.");
    }

    [Test]
    public void Deposit_NegativeAmount_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => _account.Deposit(-10), "Deposit should fail for negative amount.");
    }

    [Test]
    public void Withdraw_NegativeAmount_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => _account.Withdraw(-10), "Withdrawal should fail for negative amount.");
    }
}
