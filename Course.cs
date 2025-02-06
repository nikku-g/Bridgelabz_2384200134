using System;
using System.Collections.Generic;

// Define the Course class
class Course
{
    public string CourseName { get; set; }
    public List<Student> Students { get; set; }

    public Course(string courseName)
    {
        CourseName = courseName;
        Students = new List<Student>();
    }

    // Enroll a student in this course
    public void EnrollStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student);
            student.EnrollInCourse(this);
            Console.WriteLine($"{student.Name} has enrolled in {CourseName}");
        }
        else
        {
            Console.WriteLine($"{student.Name} is already enrolled in {CourseName}");
        }
    }

    // Display the students enrolled in this course
    public void ShowEnrolledStudents()
    {
        Console.WriteLine($"Students enrolled in {CourseName}:");
        if (Students.Count == 0)
        {
            Console.WriteLine("No students enrolled in this course.");
        }
        else
        {
            foreach (var student in Students)
            {
                Console.WriteLine($"- {student.Name}");
            }
        }
    }
}

// Define the Student class
class Student
{
    public string Name { get; set; }
    public List<Course> Courses { get; set; }

    public Student(string name)
    {
        Name = name;
        Courses = new List<Course>();
    }

    // Enroll in a course
    public void EnrollInCourse(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course);
        }
    }

    // Display the courses the student is enrolled in
    public void ShowEnrolledCourses()
    {
        Console.WriteLine($"{Name} is enrolled in the following courses:");
        if (Courses.Count == 0)
        {
            Console.WriteLine("No courses enrolled.");
        }
        else
        {
            foreach (var course in Courses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }
        }
    }
}

// Define the School class
class School
{
    public string SchoolName { get; set; }
    public List<Student> Students { get; set; }

    public School(string schoolName)
    {
        SchoolName = schoolName;
        Students = new List<Student>();
    }

    // Add a student to the school
    public void AddStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student);
            Console.WriteLine($"{student.Name} has been added to {SchoolName}");
        }
    }

    // Display all students in the school
    public void ShowAllStudents()
    {
        Console.WriteLine($"Students in {SchoolName}:");
        if (Students.Count == 0)
        {
            Console.WriteLine("No students enrolled in this school.");
        }
        else
        {
            foreach (var student in Students)
            {
                Console.WriteLine($"- {student.Name}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a school
        School school = new School("Delhi public School");

        // Create some students
        Student student1 = new Student("Vishal");
        Student student2 = new Student("Vijay");

        // Add students to the school
        school.AddStudent(student1);
        school.AddStudent(student2);

        // Create some courses
        Course course1 = new Course("Mathematics");
        Course course2 = new Course("Science");

        // Enroll students in courses
        course1.EnrollStudent(student1);
        course1.EnrollStudent(student2);
        course2.EnrollStudent(student1);

        // Show the enrolled courses for each student
        student1.ShowEnrolledCourses();
        student2.ShowEnrolledCourses();

        // Show the students enrolled in each course
        course1.ShowEnrolledStudents();
        course2.ShowEnrolledStudents();

        // Show all students in the school
        school.ShowAllStudents();
    }
}
