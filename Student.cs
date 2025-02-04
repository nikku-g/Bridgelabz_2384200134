
using System;

class Student
{
    public int rollNumber; // Public attribute
    protected string name; // Protected attribute
    private double CGPA;   // Private attribute

    // Constructor to initialize student details
    public Student(int rollNumber, string name, double CGPA)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = CGPA;
    }

    // Method to get CGPA
    public double GetCGPA()
    {
        return CGPA;
    }

    // Method to set CGPA
    public void SetCGPA(double newCGPA)
    {
        if (newCGPA >= 0.0 && newCGPA <= 10.0)
        {
            CGPA = newCGPA;
        }
        else
        {
            Console.WriteLine("Invalid CGPA value. Please enter a value between 0.0 and 10.0.");
        }
    }
}

// Subclass demonstrating access to protected member
class PostgraduateStudent : Student
{
    private string specialization;

    // Constructor using base class constructor
    public PostgraduateStudent(int rollNumber, string name, double CGPA, string specialization) : base(rollNumber, name, CGPA)
    {
        this.specialization = specialization;
    }

    // Method to display student details
    public void DisplayDetails()
    {
        Console.WriteLine("Roll Number: {0}, Name: {1}, Specialization: {2}, CGPA: {3}", rollNumber, name, specialization, GetCGPA());
    }
}

class Program
{
    public static void Main()
    {
        // Creating a student instance
        Student student1 = new Student(101, "Alice", 8.5);
		
		// Student Name is inaccessible due to protected specifier
        Console.WriteLine("Student Roll Number: {0}, CGPA: {1}", student1.rollNumber, student1.GetCGPA());
        
        // Modifying CGPA
        student1.SetCGPA(9.2);
        Console.WriteLine("Updated CGPA: {0}", student1.GetCGPA());

        Console.WriteLine();

        // Creating a postgraduate student instance
        PostgraduateStudent pgStudent = new PostgraduateStudent(102, "Bob", 9.0, "Machine Learning");
        pgStudent.DisplayDetails();
    }
}

