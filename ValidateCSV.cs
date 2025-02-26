using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace CSVDataHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Path for the CSV file
            string path = "Employees.csv";

            try
            {
                using (var reader = new StreamReader(path))
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read and open the csv file
                    var records = csvReader.GetRecords<Employee>().ToList();
                    List<Employee> validRecords = new List<Employee>();
                    List<Employee> invalidRecords = new List<Employee>();

                    foreach (var record in records)
                    {
                        if (IsValidEmail(record.Email) && IsValidPhoneNumber(record.PhoneNumber))
                        {
                            validRecords.Add(record);
                        }
                        else
                        {
                            invalidRecords.Add(record);
                        }
                    }

                    // Print invalid records with errors
                    Console.WriteLine("Invalid Records:");
                    foreach (var record in invalidRecords)
                    {
                        Console.WriteLine($"ID: {record.ID}, Name: {record.Name}, Email: {record.Email}, Phone: {record.PhoneNumber} - Invalid Data");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Method to check valid email
        static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
        }

        // Method to check valid phone number
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public int Salary { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}