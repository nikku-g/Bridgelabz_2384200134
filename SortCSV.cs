using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Remoting.Messaging;

namespace CSVDataHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Path for the csv file
            string path = "Employee.csv";

            try
            {
                // Using StreamReader to open and read the csv file
                using (var read = new StreamReader(path))
                using (var csvReader = new CsvReader(read, CultureInfo.InvariantCulture))
                {
                    // Sorted salary by descending order
                    var records = csvReader.GetRecords<Employee>().OrderByDescending(e => e.Salary).ToList();

                    // Print sorted employees
                    Console.WriteLine("Records sorted by salary in descending order:");
                    foreach (var record in records)
                    {
                        Console.WriteLine($"ID: {record.ID}, Name: {record.Name}, Department: {record.Department}, Salary: {record.Salary}");
                    }

                }
            }

            catch (Exception ex)
            {
                // Handling exceptions, such as file not found or access issues

                Console.WriteLine(ex.Message);
            }
        }


        class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public int Salary { get; set; }
        }

    }
}