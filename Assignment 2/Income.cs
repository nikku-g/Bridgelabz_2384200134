using System;

class Income
{
    static void Main()
    {
        Console.Write("enter your salary : ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("enter your bonus : ");
        double bonus = Convert.ToDouble(Console.ReadLine());

        double totalIncome = salary + bonus;

        Console.WriteLine("The salary is INR {0} and bonus is INR {1}. Hence, Total Income is INR {2}", salary, bonus, totalIncome);
    }
}
