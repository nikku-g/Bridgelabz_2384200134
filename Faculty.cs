using System;
using System.Collections.Generic;

// Define the Faculty class
class Faculty
{
    public string FacultyName { get; set; }
    public string Specialization { get; set; }

    public Faculty(string name, string specialization)
    {
        FacultyName = name;
        Specialization = specialization;
    }

     public override string ToString()
    {
        return $"{FacultyName}, Specialization: {Specialization}";
    }
}

// Define the Department class
class Department
{
    public string DepartmentName { get; set; }
    public List<Faculty> Faculties { get; set; }

    public Department(string name)
    {
        DepartmentName = name;
        Faculties = new List<Faculty>();
    }

    // Add a faculty member to the department
    public void AddFaculty(Faculty faculty)
    {
        Faculties.Add(faculty);
    }

    // Display all faculty members in the department
    public void DisplayFaculties()
    {
        Console.WriteLine($"Department: {DepartmentName}");
        if (Faculties.Count == 0)
        {
            Console.WriteLine("No faculty members in this department.");
        }
        else
        {
            foreach (var faculty in Faculties)
            {
                Console.WriteLine($"- {faculty}");
            }
        }
    }
}

// Define the University class
class University
{
    public string UniversityName { get; set; }
    public List<Department> Departments { get; set; }

    public University(string name)
    {
        UniversityName = name;
        Departments = new List<Department>();
    }

    // Add a department to the university
    public void AddDepartment(Department department)
    {
        Departments.Add(department);
    }

    // Display all departments in the university
    public void DisplayDepartments()
    {
        Console.WriteLine($"University: {UniversityName}");
        if (Departments.Count == 0)
        {
            Console.WriteLine("No departments in this university.");
        }
        else
        {
            foreach (var department in Departments)
            {
                department.DisplayFaculties();
            }
        }
    }

    // Simulate the deletion of the university (and all departments)
    public void DeleteUniversity()
    {
        Console.WriteLine($"University {UniversityName} is being deleted...");
        Departments.Clear(); // All departments are deleted when the university is deleted
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create faculty members
        Faculty faculty1 = new Faculty("Rohit", "Computer Science");
        Faculty faculty2 = new Faculty("Avdesh", "Physics");
        Faculty faculty3 = new Faculty("Suneel", "Mathematics");

        // Create departments
        Department csDepartment = new Department("Computer Science");
        Department physicsDepartment = new Department("Physics");

        // Add faculty to departments
        csDepartment.AddFaculty(faculty1);
        physicsDepartment.AddFaculty(faculty2);
        physicsDepartment.AddFaculty(faculty3);

        // Create university
        University university = new University("GLA University");

        // Add departments to the university
        university.AddDepartment(csDepartment);
        university.AddDepartment(physicsDepartment);

        // Display departments and faculty members before university deletion
        university.DisplayDepartments();

        // Demonstrate that faculty can exist independently of a department
        Console.WriteLine("\nFaculty members independent of departments:");
        Console.WriteLine(faculty1); // Faculty member can exist outside any department
        Console.WriteLine(faculty2);

        // Delete the university (and its departments)
        university.DeleteUniversity();

        // Show that the departments are deleted
        university.DisplayDepartments();
    }
}
