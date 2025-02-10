using System;
using System.Collections.Generic;

namespace OOPSConcept
{
    // Interface for department-related operations
    public interface IDepartment
    {
        void AssignDepartment(string department);
        string GetDepartmentDetails();
    }
    
    // Abstract class representing an Employee
    public abstract class Employee
    {
        private string empId;
        private string name;
        protected int baseSalary;
        
        // Constructor to initialize employee details
        public Employee(string empId, string name, int baseSalary)
        {
            this.empId = empId;
            this.name = name;
            this.baseSalary = baseSalary;
        }

        // Get and set methods for salary
        public int GetSalary()
        {
            return baseSalary;
        }

        public void SetSalary(int baseSalary)
        {
            if (baseSalary < 0)
                Console.WriteLine("Salary cannot be negative.");
            else
                this.baseSalary = baseSalary;
        }

        // Abstract method to calculate salary (to be implemented by derived classes)
        public abstract double CalculateSalary();

        // Method to display employee details
        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID : {empId} Name : {name} Base Salary : {baseSalary}, Final Salary : {CalculateSalary()} ");
        }
    }

    // Full-time employee class implementing IDepartment
    public class FullTimeEmployee : Employee, IDepartment
    {
        private int bonus;
        private string Department;

        // Constructor to initialize full-time employee details
        public FullTimeEmployee(string empId, string name, int baseSalary, int bonus) 
            : base(empId, name, baseSalary)
        {
            this.bonus = bonus;
        }

        // Overriding the abstract method to calculate salary
        public override double CalculateSalary()
        {
            return baseSalary + bonus;
        }

        // Department assignment method
        public void AssignDepartment(string department)
        {
            Department = department;
        }

        // Get department details
        public string GetDepartmentDetails()
        {
            return Department;
        }
    }
    
    // Part-time employee class implementing IDepartment
    public class PartTimeEmployee : Employee, IDepartment
    {
        private int workHours;
        private int hourlyRate;
        private string Department;

        // Constructor to initialize part-time employee details
        public PartTimeEmployee(string empId, string name, int workHours, int hourlyRate) 
            : base(empId, name, 0) // Base salary is 0 since salary depends on work hours
        {
            this.workHours = workHours;
            this.hourlyRate = hourlyRate;
        }

        // Overriding the abstract method to calculate salary
        public override double CalculateSalary()
        {
            return workHours * hourlyRate;
        }

        // Department assignment method
        public void AssignDepartment(string department)
        {
            Department = department;
        }

        // Get department details
        public string GetDepartmentDetails()
        {
            return Department;
        }
    }

    // Main class with program execution
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store employees
            List<Employee> employees = new List<Employee>
            {
                new FullTimeEmployee("Emp01", "Vanshita", 80000, 20000),
                new PartTimeEmployee("Emp02", "Simran", 8, 100)
            };

            // Loop through employees and display details
            foreach (Employee employee in employees)
            {
                employee.DisplayDetails();
            }
        }
    }
}