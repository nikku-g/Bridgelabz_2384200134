using System;
using System.Collections.Generic;

class BankingSystem
{
    // Dictionary to store account number and balance
    private Dictionary<int, double> accounts = new Dictionary<int, double>();

    // SortedDictionary to store customers sorted by their account balance (ascending order)
    private SortedDictionary<double, List<int>> sortedAccounts = new SortedDictionary<double, List<int>>();

    // Queue to store withdrawal requests
    private Queue<Tuple<int, double>> withdrawalRequests = new Queue<Tuple<int, double>>();

    // Method to create a new account
    public void CreateAccount(int accountNumber, double initialBalance)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            Console.WriteLine($"Account number {accountNumber} already exists.");
            return;
        }

        accounts.Add(accountNumber, initialBalance);
        AddToSortedAccounts(accountNumber, initialBalance);
        Console.WriteLine($"Account {accountNumber} created with an initial balance of ${initialBalance:F2}");
    }

    // Method to deposit into an account
    public void Deposit(int accountNumber, double amount)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            accounts[accountNumber] += amount;
            Console.WriteLine($"Deposited ${amount:F2} into account {accountNumber}. New balance: ${accounts[accountNumber]:F2}");

            // Update SortedDictionary
            UpdateSortedAccounts(accountNumber);
        }
        else
        {
            Console.WriteLine($"Account number {accountNumber} does not exist.");
        }
    }

    // Method to request a withdrawal (queued)
    public void RequestWithdrawal(int accountNumber, double amount)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            withdrawalRequests.Enqueue(new Tuple<int, double>(accountNumber, amount));
            Console.WriteLine($"Withdrawal request of ${amount:F2} added to queue for account {accountNumber}");
        }
        else
        {
            Console.WriteLine($"Account number {accountNumber} does not exist.");
        }
    }

    // Method to process the withdrawal requests (FIFO)
    public void ProcessWithdrawals()
    {
        while (withdrawalRequests.Count > 0)
        {
            var request = withdrawalRequests.Dequeue();
            int accountNumber = request.Item1;
            double amount = request.Item2;

            if (accounts[accountNumber] >= amount)
            {
                accounts[accountNumber] -= amount;
                Console.WriteLine($"Processed withdrawal of ${amount:F2} from account {accountNumber}. Remaining balance: ${accounts[accountNumber]:F2}");

                // Update SortedDictionary after withdrawal
                UpdateSortedAccounts(accountNumber);
            }
            else
            {
                Console.WriteLine($"Insufficient balance in account {accountNumber} for withdrawal of ${amount:F2}. Withdrawal request rejected.");
            }
        }
    }

    // Method to display all accounts and their balances (unsorted)
    public void DisplayAllAccounts()
    {
        Console.WriteLine("\nAll Accounts (Unsorted):");
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account {account.Key}: ${account.Value:F2}");
        }
    }

    // Method to display customers sorted by their balance
    public void DisplaySortedAccounts()
    {
        Console.WriteLine("\nAccounts sorted by balance:");
        foreach (var balance in sortedAccounts)
        {
            foreach (var accountNumber in balance.Value)
            {
                Console.WriteLine($"Account {accountNumber}: ${balance.Key:F2}");
            }
        }
    }

    // Helper method to add an account to the SortedDictionary
    private void AddToSortedAccounts(int accountNumber, double balance)
    {
        if (!sortedAccounts.ContainsKey(balance))
        {
            sortedAccounts[balance] = new List<int>();
        }
        sortedAccounts[balance].Add(accountNumber);
    }

    // Helper method to update the SortedDictionary after a deposit or withdrawal
    private void UpdateSortedAccounts(int accountNumber)
    {
        double oldBalance = accounts[accountNumber];

        // Remove old balance from SortedDictionary
        sortedAccounts[oldBalance].Remove(accountNumber);
        if (sortedAccounts[oldBalance].Count == 0)
        {
            sortedAccounts.Remove(oldBalance);
        }

        // Add the new balance to SortedDictionary
        double newBalance = accounts[accountNumber];
        AddToSortedAccounts(accountNumber, newBalance);
    }
}

class Program
{
    static void Main()
    {
        BankingSystem bankingSystem = new BankingSystem();

        // Create some accounts
        bankingSystem.CreateAccount(101, 500.00);
        bankingSystem.CreateAccount(102, 1500.00);
        bankingSystem.CreateAccount(103, 300.00);

        // Display all accounts (unsorted)
        bankingSystem.DisplayAllAccounts();

        // Deposit into accounts
        bankingSystem.Deposit(101, 200.00);
        bankingSystem.Deposit(102, 500.00);
        bankingSystem.Deposit(103, 100.00);

        // Display accounts sorted by balance
        bankingSystem.DisplaySortedAccounts();

        // Request withdrawals
        bankingSystem.RequestWithdrawal(101, 100.00);
        bankingSystem.RequestWithdrawal(102, 2500.00); // Insufficient balance
        bankingSystem.RequestWithdrawal(103, 50.00);

        // Process withdrawals
        bankingSystem.ProcessWithdrawals();

        // Display accounts after withdrawals
        bankingSystem.DisplaySortedAccounts();
    }
}
