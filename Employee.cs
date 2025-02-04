
using System;

class Employee
{
    public int employeeID; // Public attribute
    protected string department; // Protected attribute
    private double salary; // Private attribute

    // Constructor to initialize employee details
    public Employee(int employeeID, string department, double salary)
    {
        this.employeeID = employeeID;
        this.department = department;
        this.salary = salary;
    }

    // Method to get salary
    public double GetSalary()
    {
        return salary;
    }

    // Method to set salary
    public void SetSalary(double newSalary)
    {
        if (newSalary >= 0)
        {
            salary = newSalary;
        }
        else
        {
            Console.WriteLine("Invalid salary amount. Salary cannot be negative.");
        }
    }
}

// Subclass demonstrating access to public and protected members
class Manager : Employee
{
    private string teamName;

    // Constructor using base class constructor
    public Manager(int employeeID, string department, double salary, string teamName) 
        : base(employeeID, department, salary)
    {
        this.teamName = teamName;
    }

    // Method to display manager details
    public void DisplayDetails()
    {
        Console.WriteLine("Employee ID: {0}, Department: {1}, Salary: {2}, Team: {3}", employeeID, department, GetSalary(), teamName);
    }
}

class Program
{
    static void Main()
    {
        // Creating an employee instance
        Employee emp1 = new Employee(1001, "IT", 60000.00);
        Console.WriteLine("Employee ID: {0}, Salary: {1}", emp1.employeeID, emp1.GetSalary());
        
        // Modifying salary
        emp1.SetSalary(65000.00);
        Console.WriteLine("Updated Salary: {0}", emp1.GetSalary());

        Console.WriteLine();

        // Creating a manager instance
        Manager mgr1 = new Manager(1002, "HR", 80000.00, "Recruitment");
        mgr1.DisplayDetails();
    }
}

