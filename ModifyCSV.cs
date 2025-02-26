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
            string output = "Employees-Updated.csv";

            try
            {
                

                // Using StreamReader to open and read the csv file
                using (var read = new StreamReader(path))
                using (var csvReader = new CsvReader(read, CultureInfo.InvariantCulture))
                {
                    var records = new List<Employee>(csvReader.GetRecords<Employee>());
                    foreach (var record in records)
                    {
                        if (record.Department == "IT")
                        {
                            record.Salary += (int)(record.Salary * 0.10);
                        }
                    }

                    using (var write = new StreamWriter(output))
                    using (var csvWriter = new CsvWriter(write, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(records);
                    }
                }

                Console.WriteLine($"Updated salaries saved to {output}");
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