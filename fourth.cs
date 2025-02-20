using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main()
    {
        // List of employees to serialize
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Department = "IT", Salary = 70000 },
            new Employee { Id = 3, Name = "Sam Brown", Department = "Finance", Salary = 60000 }
        };

        string filePath = "employees.dat"; // File to store serialized data

        // Serialize employees to file
        SerializeEmployees(employees, filePath);

        // Deserialize employees from file
        List<Employee> deserializedEmployees = DeserializeEmployees(filePath);

        // Display deserialized employees
        Console.WriteLine("\nDeserialized Employees:");
        foreach (var employee in deserializedEmployees)
        {
            Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary}");
        }
    }

    // Method to serialize a list of employees to a file
    static void SerializeEmployees(List<Employee> employees, string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, employees);
            }
            Console.WriteLine("\nEmployee data has been serialized to the file.");
        }
        catch (SerializationException ex)
        {
            Console.WriteLine("Serialization error: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O error: " + ex.Message);
        }
    }

    // Method to deserialize a list of employees from a file
    static List<Employee> DeserializeEmployees(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                IFormatter formatter = new BinaryFormatter();
                return (List<Employee>)formatter.Deserialize(fs);
            }
        }
        catch (SerializationException ex)
        {
            Console.WriteLine("Serialization error during deserialization: " + ex.Message);
            return null;
        }
        catch (IOException ex)
        {
            Console.WriteLine("File I/O error during deserialization: " + ex.Message);
            return null;
        }
    }
}

// Employee class with properties to be serialized
[Serializable]  // Mark the class as serializable
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}
