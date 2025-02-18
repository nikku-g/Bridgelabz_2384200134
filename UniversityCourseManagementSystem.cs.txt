using System;
using System.Collections.Generic;

namespace Generics
{
    // Abstract base class representing a general course type
    abstract class CourseType
    {
        public string name { get; set; }  // Name of the course
        public double price { get; set; } // Price of the course

        // Constructor to initialize the course
        public CourseType(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        // Abstract method that must be implemented by all derived classes
        public abstract void ShowDetails();
    }

    // ExamCourse class inheriting from CourseType
    class ExamCourse : CourseType
    {
        public string subject { get; set; } // Subject of the exam course

        // Constructor to initialize an ExamCourse item
        public ExamCourse(string name, double price, string subject) : base(name, price)
        {
            this.subject = subject;
        }

        // Implementation of ShowDetails() for ExamCourse
        public override void ShowDetails()
        {
            // Display details of the exam course
            Console.WriteLine($"[ExamCourse] {name} - {subject} - ${price}");
        }
    }

    // AssignmentCourse class inheriting from CourseType
    class AssignmentCourse : CourseType
    {
        public string expiryDate { get; set; } // Expiry date of the assignment course

        // Constructor to initialize an AssignmentCourse item
        public AssignmentCourse(string name, double price, string expiryDate) : base(name, price)
        {
            this.expiryDate = expiryDate;
        }

        // Implementation of ShowDetails() for AssignmentCourse
        public override void ShowDetails()
        {
            // Display details of the assignment course
            Console.WriteLine($"[AssignmentCourse] {name} - Expiry: {expiryDate} - ${price}");
        }
    }

    // Generic Course class to store different types of course items
    class Course<T> where T : CourseType
    {
        private List<T> courses = new List<T>(); // List to store the courses

        // Method to add a course to the storage
        public void AddItem(T item)
        {
            courses.Add(item); // Adds the course to the list
        }

        // Method to display all stored courses
        public void DisplayAllItems()
        {
            Console.WriteLine("\nCourse Management System:");
            // Loop through all courses and display their details
            foreach (var item in courses)
            {
                item.ShowDetails();
            }
        }
    }

    // Main program class
    class Program1
    {
        static void Main()
        {
            // Creating storage for different categories of courses
            Course<ExamCourse> examCourse = new Course<ExamCourse>();
            Course<AssignmentCourse> assignmentCourse = new Course<AssignmentCourse>();

            // Adding ExamCourse items
            examCourse.AddItem(new ExamCourse("GeeksForGeeks", 5000, "Java"));
            examCourse.AddItem(new ExamCourse("TutorialsPoint", 3000, ".Net Framework"));

            // Adding AssignmentCourse items
            assignmentCourse.AddItem(new AssignmentCourse("Software Engineering", 1300, "2025-01-10"));
            assignmentCourse.AddItem(new AssignmentCourse("Cloud Computing", 2000, "2024-02-20"));

            // Displaying all stored ExamCourse items
            examCourse.DisplayAllItems();
            // Displaying all stored AssignmentCourse items
            assignmentCourse.DisplayAllItems();
        }
    }
}