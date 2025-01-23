using System;

class Seventeenth{
    static void Main(string[]args){
        // Taking input for salary and years of service
        Console.Write("Enter the salary of employee: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the years of service of employee: ");
        int yearsOfService = Convert.ToInt32(Console.ReadLine());

        // Initialize bonus variable
        double bonus = 0;

        // Check if the employee's years of service are greater than 5
        if (yearsOfService > 5){
            
			// Calculate 5% bonus according to salary
            bonus = salary * 0.05;
        }
		else{
			Console.WriteLine("you are not elegible for bonus");
		}

        // Print the bonus amount
        Console.WriteLine("The bonus amount is: " + bonus);
    }
}
