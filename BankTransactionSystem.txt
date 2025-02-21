using System;

namespace BankTransactionSystem
{
    // Custom exception for insufficient funds
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }

    class BankAccount
    {
        public double Balance { get; private set; }

        // Constructor to initialize balance
        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        // Method to handle withdrawal
        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Invalid amount!");
            }
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Insufficient balance!");
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawal successful, new balance: {Balance}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Initializing account with a balance
                Console.WriteLine("Enter initial balance:");
                double initialBalance = double.Parse(Console.ReadLine());
                BankAccount account = new BankAccount(initialBalance);

                // Taking withdrawal amount
                Console.WriteLine("Enter withdrawal amount:");
                double withdrawalAmount = double.Parse(Console.ReadLine());

                // Attempt to withdraw
                account.Withdraw(withdrawalAmount);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numeric values.");
            }
        }
    }
}