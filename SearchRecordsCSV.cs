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
                // Prompt user to enter the employee name to search
                Console.Write("Enter employee name to search: ");
                string searchName = Console.ReadLine().Trim();

                // Using StreamReader to open and read the csv file
                using (var read = new StreamReader(path))
                using (var csv = new CsvReader(read, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Employee>();
                    foreach (var record in records)
                    {
                        // Search employee by name
                        if (record.Name == searchName)
                        {
                            Console.WriteLine($"Department: {record.Department}, Salary: {record.Salary}");
                        }

                        else
                        {
                            Console.WriteLine($"Employee not found");
                        }
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