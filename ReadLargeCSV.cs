using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Collections.Generic;

namespace LargeCSVProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSV file path
            string filePath = "LargeEmployees.csv";
            int batchSize = 100; // Process 100 records at a time
            int totalRecordsProcessed = 0;

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    // Read records one by one (memory efficient)
                    var records = csv.GetRecords<Employee>();

                    List<Employee> batch = new List<Employee>();
                    foreach (var record in records)
                    {
                        batch.Add(record);

                        // Process when batch size reaches 100
                        if (batch.Count == batchSize)
                        {
                            ProcessBatch(batch);
                            totalRecordsProcessed += batch.Count;
                            batch.Clear(); // Clear the batch after processing
                        }
                    }

                    // Process any remaining records
                    if (batch.Count > 0)
                    {
                        ProcessBatch(batch);
                        totalRecordsProcessed += batch.Count;
                    }

                    Console.WriteLine($" Total Records Processed: {totalRecordsProcessed}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        // Simulated processing function
        static void ProcessBatch(List<Employee> batch)
        {
            Console.WriteLine($"Processing {batch.Count} records...");
        }
    }

    // Employee class for CSV mapping
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
}