using System;

// Base class: BankAccount
class BankAccount
{
    public int AccountNumber { get; set; }
    public double Balance { get; set; }

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public virtual void DisplayAccountType()
    {
        Console.WriteLine("Generic Bank Account");
    }
}

// Subclass: SavingsAccount
class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(int accountNumber, double balance, double interestRate) : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Savings Account");
    }
}

// Subclass: CheckingAccount
class CheckingAccount : BankAccount
{
    public double WithdrawalLimit { get; set; }

    public CheckingAccount(int accountNumber, double balance, double withdrawalLimit) : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Checking Account");
    }
}

// Subclass: FixedDepositAccount
class FixedDepositAccount : BankAccount
{
    public int DepositTerm { get; set; } // Term in months

    public FixedDepositAccount(int accountNumber, double balance, int depositTerm) : base(accountNumber, balance)
    {
        DepositTerm = depositTerm;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Fixed Deposit Account");
    }
}

// Main program
class Program
{
    static void Main()
    {
        BankAccount savings = new SavingsAccount(1001, 5000, 3.5);
        BankAccount checking = new CheckingAccount(1002, 2000, 1000);
        BankAccount fixedDeposit = new FixedDepositAccount(1003, 10000, 12);
        
        savings.DisplayAccountType();
        checking.DisplayAccountType();
        fixedDeposit.DisplayAccountType();
    }
}
