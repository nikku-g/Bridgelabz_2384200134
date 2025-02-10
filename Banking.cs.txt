using System;
using System.Collections.Generic;

// Interface for loan-related operations
public interface ILoanable
{
    void ApplyForLoan(double amount);
    bool CalculateLoanEligibility();
}

// Abstract class representing a Bank Account
public abstract class BankAccount : ILoanable
{
    protected string accountNumber;
    protected string holderName;
    protected double balance;

    // Constructor to initialize bank account details
    public BankAccount(string accountNumber, string holderName, double balance)
    {
        this.accountNumber = accountNumber;
        this.holderName = holderName;
        this.balance = balance;
    }

    // Deposit method
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}. New Balance: {balance}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    // Withdraw method with validation
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. New Balance: {balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }

    // Abstract method for interest calculation
    public abstract double CalculateInterest();

    // Implementing loan application method
    public void ApplyForLoan(double amount)
    {
        Console.WriteLine($"Loan application submitted for amount: {amount}");
    }

    // Implementing loan eligibility method
    public bool CalculateLoanEligibility()
    {
        return balance >= 5000; // Example: Eligible if balance is at least 5000
    }

    // Virtual method to display account details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Account Number: {accountNumber}\nHolder Name: {holderName}\nBalance: {balance}\nInterest Earned: {CalculateInterest()}\nLoan Eligibility: {(CalculateLoanEligibility() ? "Eligible" : "Not Eligible")}\n");
    }
}

// SavingsAccount class inheriting from BankAccount
public class SavingsAccount : BankAccount
{
    private double interestRate = 0.04; // 4% annual interest

    public SavingsAccount(string accountNumber, string holderName, double balance)
        : base(accountNumber, holderName, balance) { }

    public override double CalculateInterest()
    {
        return balance * interestRate;
    }
}

// CurrentAccount class inheriting from BankAccount
public class CurrentAccount : BankAccount
{
    private double interestRate = 0.02; // 2% annual interest

    public CurrentAccount(string accountNumber, string holderName, double balance)
        : base(accountNumber, holderName, balance) { }

    public override double CalculateInterest()
    {
        return balance * interestRate;
    }
}

// Main program class
internal class Program
{
    public static void Main(string[] args)
    {
        // List to store different bank accounts
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("SA123", "Vanshita", 10000),
            new CurrentAccount("CA456", "Simran", 7000),
            new SavingsAccount("SA789", "Misti", 3000)
        };

        // Display details and calculate interest dynamically
        foreach (var account in accounts)
        {
            account.DisplayDetails();
        }
    }
}