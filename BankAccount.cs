
using System;

class BankAccount
{
    public int accountNumber; // Public attribute
    protected string accountHolder; // Protected attribute
    private double balance; // Private attribute

    // Constructor to initialize account details
    public BankAccount(int accountNumber, string accountHolder, double balance)
    {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    // Method to get balance
    public double GetBalance()
    {
        return balance;
    }

    // Method to set balance
    public void SetBalance(double newBalance)
    {
        if (newBalance >= 0)
        {
            balance = newBalance;
        }
        else
        {
            Console.WriteLine("Invalid balance amount. Balance cannot be negative.");
        }
    }
}

// Subclass demonstrating access to public and protected members
class SavingsAccount : BankAccount
{
    private double interestRate;

    // Constructor using base class constructor
    public SavingsAccount(int accountNumber, string accountHolder, double balance, double interestRate) 
        : base(accountNumber, accountHolder, balance)
    {
        this.interestRate = interestRate;
    }

    // Method to display savings account details
    public void DisplayDetails()
    {
        Console.WriteLine("Account Number: {0}, Account Holder: {1}, Balance: {2}, Interest Rate: {3}%", accountNumber, accountHolder, GetBalance(), interestRate);
    }
}

class Program
{
    static void Main()
    {
        // Creating a bank account instance
        BankAccount account1 = new BankAccount(101234, "Alice Brown", 5000.00);
        Console.WriteLine("Account Number: {0}, Balance: {1}", account1.accountNumber, account1.GetBalance());
        
        // Modifying balance
        account1.SetBalance(5500.00);
        Console.WriteLine("Updated Balance: {0}", account1.GetBalance());

        Console.WriteLine();

        // Creating a savings account instance
        SavingsAccount savings1 = new SavingsAccount(102345, "Bob Smith", 7000.00, 2.5);
        savings1.DisplayDetails();
    }
}

