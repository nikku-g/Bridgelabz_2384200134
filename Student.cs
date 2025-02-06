using System;
using System.Collections.Generic;

// Define the Student class
class Student
{
    public string StudentName { get; set; }
    public List<Course> EnrolledCourses { get; set; }

    public Student(string name)
    {
        StudentName = name;
        EnrolledCourses = new List<Course>();
    }

    // Method for enrolling a student in a course
    public void EnrollCourse(Course course)
    {
        if (!EnrolledCourses.Contains(course))
        {
            EnrolledCourses.Add(course);
            course.AddStudent(this);
            Console.WriteLine($"{StudentName} has enrolled in {course.CourseName}");
        }
        else
        {
            Console.WriteLine($"{StudentName} is already enrolled in {course.CourseName}");
        }
    }

    // Method to display the student's enrolled courses
    public void DisplayEnrolledCourses()
    {
        Console.WriteLine($"{StudentName} is enrolled in the following courses:");
        foreach (var course in EnrolledCourses)
        {
            Console.WriteLine($"- {course.CourseName}");
        }
    }
}

// Define the Professor class
class Professor
{
    public string ProfessorName { get; set; }
    public List<Course> TaughtCourses { get; set; }

    public Professor(string name)
    {
        ProfessorName = name;
        TaughtCourses = new List<Course>();
    }

    // Method for assigning a professor to a course
    public void AssignProfessor(Course course)
    {
        if (!TaughtCourses.Contains(course))
        {
            TaughtCourses.Add(course);
            course.Professor = this;
            Console.WriteLine($"{ProfessorName} is assigned to teach {course.CourseName}");
        }
        else
        {
            Console.WriteLine($"{ProfessorName} is already teaching {course.CourseName}");
        }
    }

    // Method to display the courses taught by the professor
    public void DisplayTaughtCourses()
    {
        Console.WriteLine($"{ProfessorName} teaches the following courses:");
        foreach (var course in TaughtCourses)
        {
            Console.WriteLine($"- {course.CourseName}");
        }
    }
}

// Define the Course class
class Course
{
    public string CourseName { get; set; }
    public Professor Professor { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public Course(string courseName)
    {
        CourseName = courseName;
        EnrolledStudents = new List<Student>();
    }

    // Method to add a student to the course
    public void AddStudent(Student student)
    {
        if (!EnrolledStudents.Contains(student))
        {
            EnrolledStudents.Add(student);
            Console.WriteLine($"{student.StudentName} is added to the course {CourseName}");
        }
        else
        {
            Console.WriteLine($"{student.StudentName} is already enrolled in the course {CourseName}");
        }
    }

    // Method to display the course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {CourseName}");
        if (Professor != null)
        {
            Console.WriteLine($"Professor: {Professor.ProfessorName}");
        }
        else
        {
            Console.WriteLine("Professor: Not assigned yet.");
        }

        Console.WriteLine("Enrolled Students:");
        if (EnrolledStudents.Count == 0)
        {
            Console.WriteLine("No students enrolled.");
        }
        else
        {
            foreach (var student in EnrolledStudents)
            {
                Console.WriteLine($"- {student.StudentName}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create professors
        Professor professor1 = new Professor("Rohit");
        Professor professor2 = new Professor("Sachendra");

        // Create courses
        Course course1 = new Course("Python");
        Course course2 = new Course("Java");
        Course course3 = new Course("CShark");

        // Assign professors to courses
        professor1.AssignProfessor(course1);
        professor2.AssignProfessor(course2);

        // Create students
        Student student1 = new Student("Yugal");
        Student student2 = new Student("Vijay");
        Student student3 = new Student("Vaibhav");

        // Students enroll in courses
        student1.EnrollCourse(course1);
        student1.EnrollCourse(course2);
        student2.EnrollCourse(course1);
        student3.EnrollCourse(course2);
        student3.EnrollCourse(course3);

        // Display the students' enrolled courses
        student1.DisplayEnrolledCourses();
        student2.DisplayEnrolledCourses();
        student3.DisplayEnrolledCourses();

        // Display course details
        course1.DisplayCourseDetails();
        course2.DisplayCourseDetails();
        course3.DisplayCourseDetails();

        // Display the professors' taught courses
        professor1.DisplayTaughtCourses();
        professor2.DisplayTaughtCourses();
    }
}
