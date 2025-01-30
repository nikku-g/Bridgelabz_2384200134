using System;

class EmployeeBonus
{
    public static void Main()
    {
        const int employeeCount = 5;
        double[,] employeeData = new double[employeeCount, 2]; // [Salary, YearsOfService]
        double[,] resultData = new double[employeeCount, 2]; // [NewSalary, BonusAmount]

        double totalOldSalary = 0, totalNewSalary = 0, totalBonus = 0;

        // Input Loop
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine("Enter details for Employee {0}:", i+1);
			
			// Input Salary
			Console.Write("Enter salary: ");
			employeeData[i, 0] = Convert.ToInt32(Console.ReadLine());
			if(employeeData[i, 0] < 0) {
				Console.Error.WriteLine("Invalid input. Please enter a positive number for salary.");
				Environment.Exit(0);
			}

            // Input years of service
			Console.Write("Enter years of service: ");
			employeeData[i, 1] = Convert.ToInt32(Console.ReadLine());
			if(employeeData[i, 1] < 0) {
				Console.Error.WriteLine("Invalid input. Please enter a non-negative number for years of service.");
				Environment.Exit(0);
			}
        }

        // Calculation Loop
        for (int i = 0; i < employeeCount; i++)
        {
            double salary = employeeData[i, 0];
            double yearsOfService = employeeData[i, 1];

            double bonus = CalculateBonus(salary, yearsOfService);
            double newSalary = salary + bonus;

            resultData[i, 0] = newSalary;
            resultData[i, 1] = bonus;

            totalOldSalary += salary;
            totalNewSalary += newSalary;
            totalBonus += bonus;
        }

        // Output Results
        Console.WriteLine("\n--- Summary ---");
        Console.WriteLine("Total Old Salary: {0}", totalOldSalary);
        Console.WriteLine("Total Bonus Payout: {0}", totalBonus);
        Console.WriteLine("Total New Salary: {0}", totalNewSalary);

        Console.WriteLine("\nEmployee Details:");
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine("Employee {0}: Old Salary = {1}, Years of Service = {2}, Bonus = {3}, New Salary = {4}", i+1, employeeData[i, 0], employeeData[i, 1], resultData[i, 1], resultData[i, 0]);
        }
    }

    static double CalculateBonus(double salary, double yearsOfService)
    {
        if (yearsOfService > 5)
        {
            return salary * 0.05; // 5% bonus
        }
        else
        {
            return salary * 0.02; // 2% bonus
        }
    }
}
