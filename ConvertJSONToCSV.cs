using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace JSONCSVConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "students.json";
            string csvFilePath = "students.csv";
            string newJsonFilePath = "students_converted.json";

            // Convert JSON to CSV
            ConvertJsonToCsv(jsonFilePath, csvFilePath);

            // Convert CSV back to JSON
            ConvertCsvToJson(csvFilePath, newJsonFilePath);
        }

        // Convert JSON to CSV
        static void ConvertJsonToCsv(string jsonFile, string csvFile)
        {
            try
            {
                string jsonData = File.ReadAllText(jsonFile);
                var students = JsonConvert.DeserializeObject<List<Student>>(jsonData);

                using (var writer = new StreamWriter(csvFile))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(students);
                }

                Console.WriteLine($" JSON successfully converted to CSV: {csvFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error converting JSON to CSV: {ex.Message}");
            }
        }

        // Convert CSV to JSON
        static void ConvertCsvToJson(string csvFile, string jsonFile)
        {
            try
            {
                using (var reader = new StreamReader(csvFile))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var students = csv.GetRecords<Student>();

                    string json = JsonConvert.SerializeObject(students, Formatting.Indented);
                    File.WriteAllText(jsonFile, json);
                }

                Console.WriteLine($" CSV successfully converted back to JSON: {jsonFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error converting CSV to JSON: {ex.Message}");
            }
        }
    }

    // Student class
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}