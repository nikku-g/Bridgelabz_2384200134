using System;

// Base class: Person
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayRole()
    {
        Console.WriteLine("Generic Person");
    }
}

// Subclass: Teacher
class Teacher : Person
{
    public string Subject { get; set; }

    public Teacher(string name, int age, string subject) : base(name, age)
    {
        Subject = subject;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Teacher of {0}", Subject);
    }
}

// Subclass: Student
class Student : Person
{
    public string Grade { get; set; }

    public Student(string name, int age, string grade) : base(name, age)
    {
        Grade = grade;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Student in Grade {0}", Grade);
    }
}

// Subclass: Staff
class Staff : Person
{
    public string Position { get; set; }

    public Staff(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Staff Member: {0}", Position);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Person teacher = new Teacher("Alice", 35, "Mathematics");
        Person student = new Student("Bob", 16, "10th Grade");
        Person staff = new Staff("Charlie", 40, "Administrator");
        
        teacher.DisplayRole();
        student.DisplayRole();
        staff.DisplayRole();
    }
}
