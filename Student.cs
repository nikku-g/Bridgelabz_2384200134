using System;

class Student
{
    // Static variable shared across all students
    public static string UniversityName = "GLA University";

    // Static variable to track total students
    private static int totalStudents = 0;

    // Readonly variable for RollNumber (cannot be changed after initialization)
    public readonly int RollNumber;

    // Instance variables
    public string Name;
    public string Grade;

    // Constructor using 'this' keyword to initialize properties
    public Student(string name, int rollNumber, string grade)
    {
        this.Name = name;
        this.RollNumber = rollNumber;
        this.Grade = grade;
        totalStudents++; // Increment student count
    }

    // Static method to display total students
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("\nTotal Students Enrolled: " + totalStudents);
    }

    // Method to display student details
    public void DisplayStudentDetails()
    {
        Console.WriteLine("\nStudent Details:");
        Console.WriteLine("University: " + UniversityName);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Roll Number: " + RollNumber);
        Console.WriteLine("Grade: " + Grade);
    }

    // Method to update grade (only if the object is an instance of Student)
    public void UpdateGrade(string newGrade)
    {
        if (this is Student)
        {
            Grade = newGrade;
            Console.WriteLine("Grade updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid student object. Cannot update grade.");
        }
    }
}

class UniversitySystem
{
    private static Student[] students = new Student[10]; // Array to store students (max 10)
    private static int studentCount = 0;

    // Method to add a new student
    public static void AddStudent()
    {
        if (studentCount >= students.Length)
        {
            Console.WriteLine("Student limit reached. Cannot add more students.");
            return;
        }

        Console.Write("\nEnter Student Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Roll Number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Grade: ");
        string grade = Console.ReadLine();

        students[studentCount] = new Student(name, rollNumber, grade);
        studentCount++;
        Console.WriteLine("Student added successfully!");
    }

    // Method to delete a student
    public static void DeleteStudent()
    {
        Console.Write("\nEnter Roll Number of Student to Delete: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i] != null && students[i].RollNumber == rollNumber)
            {
                students[i] = null;
                Console.WriteLine("Student deleted successfully!");
                return;
            }
        }
        Console.WriteLine("Student not found!");
    }

    // Method to view a student's grades
    public static void ViewStudentGrade()
    {
        Console.Write("\nEnter Roll Number of Student: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i] != null && students[i].RollNumber == rollNumber)
            {
                Console.WriteLine($"Student: {students[i].Name} | Grade: {students[i].Grade}");
                return;
            }
        }
        Console.WriteLine("Student not found!");
    }

    // Method to update a student's grade
    public static void UpdateStudentGrade()
    {
        Console.Write("\nEnter Roll Number of Student: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i] != null && students[i].RollNumber == rollNumber)
            {
                Console.Write("Enter New Grade: ");
                string newGrade = Console.ReadLine();
                students[i].UpdateGrade(newGrade);
                return;
            }
        }
        Console.WriteLine("Student not found!");
    }

    // Menu-driven method to manage students
    public static void ManageStudents()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. View Student Grades");
            Console.WriteLine("4. Update Student Grades");
            Console.WriteLine("5. View Total Students");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    ViewStudentGrade();
                    break;
                case 4:
                    UpdateStudentGrade();
                    break;
                case 5:
                    Student.DisplayTotalStudents();
                    break;
                case 6:
                    exit = true;
                    Console.WriteLine("Exiting Student Management System.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to " + Student.UniversityName);
        UniversitySystem.ManageStudents();
    }
}