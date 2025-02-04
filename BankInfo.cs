using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSystem
{
    internal class BankInfo
    {
        private static string BankName = "PNB";
        private string AccountHolderName;
        private readonly int AccountNo;
        private double AccountBalance;
        private readonly int MinBalance = 1000;
        
        public BankInfo(string AccountHolderName, int AccountNo, double AccountBalance)
        {
            this.AccountHolderName = AccountHolderName;
            this.AccountBalance = AccountBalance;
            this.AccountNo= AccountNo;
        }
        public void Deposit(double value)
        {
            AccountBalance += value;
            Console.WriteLine("Deposit Successfully");
            Console.WriteLine($"Your current Balance is {AccountBalance}");
            Console.WriteLine();
        }
        public void Withdrawl(double value)
        {
            if (value >= AccountBalance - MinBalance)
            {
                Console.WriteLine("Sorry not possible.");
                Console.WriteLine("You have to manage 1000rs as minimum balance");
                Console.WriteLine();
            }
            else
            {
                AccountBalance -= value;
                Console.WriteLine("Withdrawl Sucessfully");
                Console.WriteLine($"Your current Balance is {AccountBalance}");
                Console.WriteLine();
            }
        }
        public void Displaybalance()
        {
            Console.WriteLine($"Your current balance is: {AccountBalance}");
            Console.WriteLine();
        }
        public static void Main()
        {
            BankInfo info = new BankInfo("NIKHIL",5001,2000);
            while (true)
            {
                Console.WriteLine($"Hii {info.AccountHolderName} A/C No.{info.AccountNo}");
                Console.WriteLine($"Welcome to {BankInfo.BankName}");
                Console.WriteLine("Choose the number to perform operation");
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Deposite Amount");
                Console.WriteLine("3. Withdrawl Amount");
                Console.WriteLine("4. Change bank name");
                Console.WriteLine("5. Exit");
                int Choice = Convert.ToInt32(Console.ReadLine());
                if (info is BankInfo) 
                {
                    if (Choice == 1)
                    {
                        info.Displaybalance();

                    }
                    else if (Choice == 2)
                    {
                        Console.WriteLine("Enter amount that you want to deposit");
                        double Amount = Convert.ToDouble(Console.ReadLine());
                        info.Deposit(Amount);

                    }
                    else if (Choice == 3)
                    {
                        Console.WriteLine("Enter amount that you want to withdrawl");
                        double Amount = Convert.ToDouble(Console.ReadLine());
                        info.Withdrawl(Amount);

                    }
                    else if (Choice == 4)
                    {
                        Console.WriteLine("Enter new bank name");
                        string name = Console.ReadLine();
                        Console.WriteLine();
                        BankInfo.BankName = name;

                    }
                    else if (Choice == 5)
                    {
                        break;
                    }
                }

            }
        }
    }
}
