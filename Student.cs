using System;
using System.Collections.Generic;

public class Student
{
    public int RollNumber { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public char Grade { get; set; }

    public Student(int rollNumber, string name, int age, char grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
    }
}


public class Node
{
    public Student Data;
    public Node Next;

    public Node(Student data)
    {
        Data = data;
        Next = null;
    }
}


public class StudentList
{
    private Node head;

    public StudentList()
    {
        head = null;
    }

    // Add a new student at the beginning
    public void AddAtBeginning(Student student)
    {
        Node n = new Node(student);
        n.Next = head;
        head = n;
    }

    // Add a new student at the end
    public void AddAtEnd(Student student)
    {
        Node n = new Node(student);
        if (head == null)
        {
            head = n;
            return;
        }
        
        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = n;
    }

    // Add a new student at a specific position
    public void AddAtPosition(Student student, int position)
    {
        Node n = new Node(student);
        if (position == 0)
        {
            AddAtBeginning(student);
            return;
        }

        Node temp = head;
        for (int i = 0; temp != null && i < position - 1; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Position is out of bounds.");
            return;
        }

        n.Next = temp.Next;
        temp.Next = n;
    }

    // Delete a student by Roll Number
    public void DeleteByRollNumber(int rollNumber)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        // If the head node itself holds the RollNumber
        if (head.Data.RollNumber == rollNumber)
        {
            head = head.Next;
            return;
        }

        Node temp = head;
        while (temp.Next != null && temp.Next.Data.RollNumber != rollNumber)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
        {
            Console.WriteLine("Student not found.");
        }
        else
        {
            temp.Next = temp.Next.Next;
        }
    }

    // Search for a student by Roll Number
    public void SearchByRollNumber(int rollNumber)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.RollNumber == rollNumber)
            {
                Console.WriteLine($"Student Found: {temp.Data.Name}, Age: {temp.Data.Age}, Grade: {temp.Data.Grade}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found.");
    }

    // Update student's grade based on Roll Number
    public void UpdateGrade(int rollNumber, char newGrade)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.RollNumber == rollNumber)
            {
                temp.Data.Grade = newGrade;
                Console.WriteLine($"Student's grade updated to {newGrade}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found.");
    }

    // Display all student records
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No records to display.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine($"Roll No: {temp.Data.RollNumber}, Name: {temp.Data.Name}, Age: {temp.Data.Age}, Grade: {temp.Data.Grade}");
            temp = temp.Next;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        StudentList studentList = new StudentList();

        // Add students
        studentList.AddAtEnd(new Student(101, "umakant", 20, 'A'));
        studentList.AddAtEnd(new Student(102, "siddharth", 21, 'B'));
        studentList.AddAtBeginning(new Student(100, "vaibhav", 22, 'C'));
        
        // Display all students
        Console.WriteLine("All Students:");
        studentList.DisplayAll();

        // Update a student's grade
        Console.WriteLine("\nUpdating grade of student with Roll Number 101:");
        studentList.UpdateGrade(101, 'A+');
        studentList.DisplayAll();

        // Search for a student by Roll Number
        Console.WriteLine("\nSearching for student with Roll Number 102:");
        studentList.SearchByRollNumber(102);

        // Delete a student by Roll Number
        Console.WriteLine("\nDeleting student with Roll Number 100:");
        studentList.DeleteByRollNumber(100);
        studentList.DisplayAll();

        // Add student at specific position
        Console.WriteLine("\nAdding student at position 1:");
        studentList.AddAtPosition(new Student(103, "sahil", 23, 'd'), 1);
        studentList.DisplayAll();
    }
}
