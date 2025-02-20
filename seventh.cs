using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "student_details.dat"; // Path of the binary file

        // Store student details in the binary file
        StoreStudentDetails(filePath);

        // Retrieve and display student details from the binary file
        RetrieveStudentDetails(filePath);
    }

    // Method to store student details into a binary file
    static void StoreStudentDetails(string filePath)
    {
        // Open a FileStream for writing the binary data
        FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        BinaryWriter writer = new BinaryWriter(fileStream);

        // Write student details (roll number, name, GPA)
        int rollNumber = 123;
        string name = "John Doe";
        double gpa = 3.75;

        writer.Write(rollNumber);  // Write roll number
        writer.Write(name);        // Write name
        writer.Write(gpa);         // Write GPA

        // Close the BinaryWriter and FileStream
        writer.Close();
        fileStream.Close();

        Console.WriteLine("Student details stored successfully.");
    }

    // Method to retrieve student details from the binary file
    static void RetrieveStudentDetails(string filePath)
    {
        // Check if the file exists before reading it
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The binary file does not exist.");
            return;
        }

        // Open a FileStream for reading the binary data
        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        BinaryReader reader = new BinaryReader(fileStream);

        // Read student details (roll number, name, GPA)
        int rollNumber = reader.ReadInt32();  // Read roll number
        string name = reader.ReadString();     // Read name
        double gpa = reader.ReadDouble();      // Read GPA

        // Display the retrieved student details
        Console.WriteLine($"Roll Number: {rollNumber}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"GPA: {gpa}");

        // Close the BinaryReader and FileStream
        reader.Close();
        fileStream.Close();
    }
}
