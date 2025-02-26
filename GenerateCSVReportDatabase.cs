using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CSVReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define CSV output file path
            string csvFilePath = "EmployeeReport.csv";

            // Fetch employee data from the database
            List<Employee> employees = FetchEmployeeRecords();

            if (employees.Count > 0)
            {
                // Write data to CSV
                using (var writer = new StreamWriter(csvFilePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(employees);
                }

                Console.WriteLine($" Employee report successfully exported to: {csvFilePath}");
            }
            else
            {
                Console.WriteLine(" No records found in the database.");
            }
        }

        // Method to fetch employee records from database
        static List<Employee> FetchEmployeeRecords()
        {
            List<Employee> employeeList = new List<Employee>();

            // Database connection string
            string connectionString = "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeList.Add(new Employee
                            {
                                EmployeeID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Department = reader.GetString(2),
                                Salary = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Database Error: {ex.Message}");
            }

            return employeeList;
        }
    }

    // Employee class for CSV mapping
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}