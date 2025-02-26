using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace CSVHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSV file path
            string filePath = "Students.csv";

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read records from CSV
                    var records = csv.GetRecords<Student>().ToList();

                    // Group by ID and find duplicates
                    var duplicateRecords = records
                        .GroupBy(s => s.ID)
                        .Where(group => group.Count() > 1)
                        .SelectMany(group => group)
                        .ToList();

                    // Print duplicate records
                    if (duplicateRecords.Any())
                    {
                        Console.WriteLine(" Duplicate Records Found:");
                        foreach (var record in duplicateRecords)
                        {
                            Console.WriteLine($"ID: {record.ID}, Name: {record.Name}, Age: {record.Age}");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" No duplicate records found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }
    }

    // Student class for CSV mapping
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}