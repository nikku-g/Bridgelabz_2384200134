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
            // Path for the csv file
            string path1 = "student1.csv";
            string path2 = "student2.csv";
            string outputPath = "merged-students.csv";

            try
            {
                List<Student1> studentList1;
                using (var reader = new StreamReader(path1))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    studentList1 = new List<Student1>(csv.GetRecords<Student1>().ToList());
                }

                // Read second CSV (ID, Marks, Grade)
                List<Student2> studentList2;
                using (var reader = new StreamReader(path2))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    studentList2 = new List<Student2>(csv.GetRecords<Student2>().ToList());
                }

                // Merge both lists based on ID
                var mergedList = studentList1
                    .Join(studentList2,
                          s1 => s1.ID,
                          s2 => s2.ID,
                          (s1, s2) => new MergedStudent
                          {
                              ID = s1.ID,
                              Name = s1.Name,
                              Age = s1.Age,
                              Marks = s2.Marks,
                              Grade = s2.Grade
                          })
                    .ToList();

                // Write merged data to a new CSV
                using (var writer = new StreamWriter(outputPath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(mergedList);
                }

                Console.WriteLine("Merging complete! Check merged_students.csv.");
            }

            catch (Exception ex)
            {
                // Handling exceptions, such as file not found or access issues

                Console.WriteLine(ex.Message);
            }

        }
    }

    public class MergedStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }
        public string Grade { get; set; }
    }

    public class Student1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Student2
    {
        public int ID { get; set; }
        public int Marks { get; set; }
        public string Grade { get; set; }
    }
}