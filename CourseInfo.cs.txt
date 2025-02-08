using System;

// Base class: Course
class Course
{
    public string CourseName { get; set; }
    public int Duration { get; set; } // Duration in weeks

    public Course(string courseName, int duration)
    {
        CourseName = courseName;
        Duration = duration;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Course: {0}, Duration: {1} weeks", CourseName, Duration);
    }
}

// Subclass: OnlineCourse
class OnlineCourse : Course
{
    public string Platform { get; set; }
    public bool IsRecorded { get; set; }

    public OnlineCourse(string courseName, int duration, string platform, bool isRecorded) 
        : base(courseName, duration)
    {
        Platform = platform;
        IsRecorded = isRecorded;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Platform: {0}, Recorded: {1}", Platform, IsRecorded);
    }
}

// Subclass: PaidOnlineCourse
class PaidOnlineCourse : OnlineCourse
{
    public double Fee { get; set; }
    public double Discount { get; set; } // Discount in percentage

    public PaidOnlineCourse(string courseName, int duration, string platform, bool isRecorded, double fee, double discount) 
        : base(courseName, duration, platform, isRecorded)
    {
        Fee = fee;
        Discount = discount;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Fee: ${0}, Discount: {1}%", Fee, Discount);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Course course = new Course("Intro to Programming", 6);
        OnlineCourse onlineCourse = new OnlineCourse("Web Development", 8, "Udemy", true);
        PaidOnlineCourse paidCourse = new PaidOnlineCourse("Data Science", 12, "Coursera", true, 299.99, 20);
        
        course.DisplayInfo();
        Console.WriteLine();
        onlineCourse.DisplayInfo();
        Console.WriteLine();
        paidCourse.DisplayInfo();
    }
}
