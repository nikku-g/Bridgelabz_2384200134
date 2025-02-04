using System;

class Employee
{
    // Static variable shared by all employees
    public static string CompanyName = "TechCorp";

    // Static field to track the total number of employees
    private static int totalEmployees = 0;

    // Readonly variable for employee ID
    public readonly int Id;

    // Instance properties
    public string Name { get; private set; }
    public string Designation { get; private set; }

    // Constructor using 'this' to initialize fields
    public Employee(int id, string name, string designation)
    {
        this.Id = id;
        this.Name = name;
        this.Designation = designation;

        // Increment total employee count
        totalEmployees++;
    }

    // Static method to display the total number of employees
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine($"Total Employees: {totalEmployees}");
    }

    // Method to display employee details
    public void DisplayDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Designation: {Designation}, Company: {CompanyName}");
    }

    public void UpdateInformation(string name, string designation)
    {
        this.Name = name;
        this.Designation = designation;
        Console.WriteLine("Employee information updated successfully.");
    }
}

class Program
{
    private static Employee[] employees = new Employee[100];
    private static int employeeCount = 0;
    private static int currentId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEmployee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee Information");
            Console.WriteLine("3. Delete Employee Record");
            Console.WriteLine("4. Search Employee by Designation");
            Console.WriteLine("5. Display All Employees");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;

                case 2:
                    UpdateEmployee();
                    break;

                case 3:
                    DeleteEmployee();
                    break;

                case 4:
                    SearchEmployeeByDesignation();
                    break;

                case 5:
                    DisplayAllEmployees();
                    break;

                case 6:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddEmployee()
    {
        if (employeeCount >= employees.Length)
        {
            Console.WriteLine("Employee list is full. Cannot add more employees.");
            return;
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Designation: ");
        string designation = Console.ReadLine();

        employees[employeeCount++] = new Employee(currentId++, name, designation);
        Console.WriteLine("Employee added successfully.");
    }

    private static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID to Update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Employee employee = FindEmployeeById(id);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Designation: ");
        string designation = Console.ReadLine();

        employee.UpdateInformation(name, designation);
    }

    private static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to Delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        int index = FindEmployeeIndexById(id);
        if (index == -1)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        // Shift elements left to fill the gap
        for (int i = index; i < employeeCount - 1; i++)
        {
            employees[i] = employees[i + 1];
        }

        employees[--employeeCount] = null;
        Console.WriteLine("Employee deleted successfully.");
    }

    private static void SearchEmployeeByDesignation()
    {
        Console.Write("Enter Designation to Search: ");
        string designation = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < employeeCount; i++)
        {
            if (employees[i].Designation.Equals(designation, StringComparison.OrdinalIgnoreCase))
            {
                employees[i].DisplayDetails();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No employees found with the given designation.");
        }
    }

    private static void DisplayAllEmployees()
    {
        if (employeeCount == 0)
        {
            Console.WriteLine("No employees to display.");
        }
        else
        {
            Console.WriteLine("All Employees:");
            for (int i = 0; i < employeeCount; i++)
            {
                employees[i].DisplayDetails();
            }
        }
    }

    private static Employee FindEmployeeById(int id)
    {
        for (int i = 0; i < employeeCount; i++)
        {
            if (employees[i].Id == id)
            {
                return employees[i];
            }
        }
        return null;
    }

    private static int FindEmployeeIndexById(int id)
    {
        for (int i = 0; i < employeeCount; i++)
        {
            if (employees[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }
}