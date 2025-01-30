using System;

class ZaraBonusProgram
{
    // Method to generate random salary and years of service for employees
    static double[,] GenerateEmployeeData(int numEmployees)
    {
        Random rand = new Random();
		// 2D array: [0] = salary, [1] = years of service
        double[,] employeeData = new double[numEmployees, 2]; 

        for (int i = 0; i < numEmployees; i++)
        {
            // Random 5-digit salary (between 10000 and 99999)
            employeeData[i, 0] = rand.Next(10000, 100000);

            // Random years of service (between 1 and 15)
            employeeData[i, 1] = rand.Next(1, 16);
        }

        return employeeData;
    }

    // Method to calculate the new salary and bonus based on years of service
    static double[,] CalculateBonusAndNewSalary(double[,] employeeData, int numEmployees)
    {
		// [0] = old salary, [1] = bonus, [2] = new salary
        double[,] updatedData = new double[numEmployees, 3]; 

        for (int i = 0; i < numEmployees; i++)
        {
            double oldSalary = employeeData[i, 0];
            double yearsOfService = employeeData[i, 1];
            double bonus = 0;

            // Bonus logic
            if (yearsOfService > 5)
            {
				// 5% bonus for service more than 5 
                bonus = oldSalary * 0.05;  years
            }
            else
            {
				// 2% bonus for service less than 5 years
                bonus = oldSalary * 0.02;  
            }

            // Calculate new salary (old salary + bonus)
            double newSalary = oldSalary + bonus;

            // Store old salary, bonus, and new salary in the updated data array
            updatedData[i, 0] = oldSalary;
            updatedData[i, 1] = bonus;
            updatedData[i, 2] = newSalary;
        }

        return updatedData;
    }

    // Method to calculate the total of old salary, new salary, and total bonus
    static void CalculateAndDisplayTotals(double[,] updatedData, int numEmployees)
    {
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        double totalBonus = 0;

        Console.WriteLine("\n{0,-10} {1,-15} {2,-15} {3,-15}", "Employee", "Old Salary", "Bonus", "New Salary");
        Console.WriteLine(new string('-', 55));

        for (int i = 0; i < numEmployees; i++)
        {
            double oldSalary = updatedData[i, 0];
            double bonus = updatedData[i, 1];
            double newSalary = updatedData[i, 2];

            Console.WriteLine("{0,-10} {1,-15:C} {2,-15:C} {3,-15:C}", i + 1, oldSalary, bonus, newSalary);

            totalOldSalary += oldSalary;
            totalBonus += bonus;
            totalNewSalary += newSalary;
        }

        // Display the total salary, bonus, and new salary
        Console.WriteLine("\n{0,-10} {1,-15:C} {2,-15:C} {3,-15:C}", "Total", totalOldSalary, totalBonus, totalNewSalary);
    }

    static void Main()
    {
        int numEmployees = 10; // Zara has 10 employees

        // Generate random salary and years of service for the employees
        double[,] employeeData = GenerateEmployeeData(numEmployees);

        // Calculate bonus and new salary for each employee
        double[,] updatedData = CalculateBonusAndNewSalary(employeeData, numEmployees);

        // Calculate and display totals for old salary, bonus, and new salary
        CalculateAndDisplayTotals(updatedData, numEmployees);
    }
}
