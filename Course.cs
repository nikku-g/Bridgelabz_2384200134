
using System;

class Course
{
    private string courseName;
    private int duration; // Duration in weeks
    private double fee;
    private static string instituteName = "Default Institute";

    // Constructor to initialize course details
    public Course(string courseName, int duration, double fee)
    {
        this.courseName = courseName;
        this.duration = duration;
        this.fee = fee;
    }

    // Instance method to display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Institute: {0}", instituteName);
        Console.WriteLine("Course Name: {0}, Duration: {1} weeks, Fee: Rs.{2}", courseName, duration, fee);
    }

    // Class method to update institute name
    public static void UpdateInstituteName(string newName)
    {
        instituteName = newName;
    }
}

class Program
{
    public static void Main()
    {
        // Creating course instances
        Course course1 = new Course("Data Science", 12, 120000.00);
        Course course2 = new Course("Web Development", 10, 100000.00);
        
        // Display course details before updating institute name
        Console.WriteLine("Before updating institute name:");
        course1.DisplayCourseDetails();
        course2.DisplayCourseDetails();
        
        Console.WriteLine();
        
        // Updating institute name
        Course.UpdateInstituteName("Tech Academy");
        
        // Display course details after updating institute name
        Console.WriteLine("After updating institute name:");
        course1.DisplayCourseDetails();
        course2.DisplayCourseDetails();
    }
}



