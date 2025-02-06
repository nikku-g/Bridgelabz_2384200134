using System;
using System.Collections.Generic;

// Define the Employee class
class Employee
{
    public string EmployeeName { get; set; }
    public string Position { get; set; }

    public Employee(string name, string position)
    {
        EmployeeName = name;
        Position = position;
    }

    public override string ToString()
    {
        return $"{EmployeeName} - {Position}";
    }
}

// Define the Department class
class Department
{
    public string DepartmentName { get; set; }
    public List<Employee> Employees { get; set; }

    public Department(string departmentName)
    {
        DepartmentName = departmentName;
        Employees = new List<Employee>();
    }

    // Add an employee to the department
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    // Display all employees in the department
    public void DisplayEmployees()
    {
        Console.WriteLine($"Department: {DepartmentName}");
        if (Employees.Count == 0)
        {
            Console.WriteLine("No employees in this department.");
        }
        else
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine($"- {employee}");
            }
        }
    }
}

// Define the Company class
class Company
{
    public string CompanyName { get; set; }
    public List<Department> Departments { get; set; }

    public Company(string companyName)
    {
        CompanyName = companyName;
        Departments = new List<Department>();
    }

    // Add a department to the company
    public void AddDepartment(Department department)
    {
        Departments.Add(department);
    }

    // Display all departments and employees in the company
    public void DisplayCompanyStructure()
    {
        Console.WriteLine($"Company: {CompanyName}");
        if (Departments.Count == 0)
        {
            Console.WriteLine("No departments in this company.");
        }
        else
        {
            foreach (var department in Departments)
            {
                department.DisplayEmployees();
            }
        }
    }

    // Simulate deletion of the company and all its departments and employees
    public void DeleteCompany()
    {
        Console.WriteLine($"Company {CompanyName} is being deleted...");
        Departments.Clear(); // All departments (and employees) are deleted when the company is deleted
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create employees
        Employee emp1 = new Employee("sahil", "Software Engineer");
        Employee emp2 = new Employee("prabhat", "HR Manager");
        Employee emp3 = new Employee("chandra", "Sales Executive");

        // Create departments
        Department devDepartment = new Department("Development");
        Department hrDepartment = new Department("Sales");

        // Add employees to departments
        devDepartment.AddEmployee(emp1);
        hrDepartment.AddEmployee(emp2);
        hrDepartment.AddEmployee(emp3);

        // Create company
        Company company = new Company("Bridge labz");

        // Add departments to the company
        company.AddDepartment(devDepartment);
        company.AddDepartment(hrDepartment);

        // Display company structure before deletion
        company.DisplayCompanyStructure();

        // Delete the company (this will also delete all departments and employees)
        company.DeleteCompany();

        // Attempt to display company structure after deletion
        company.DisplayCompanyStructure();
    }
}
