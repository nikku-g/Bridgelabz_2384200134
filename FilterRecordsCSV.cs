using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVDataHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Path for the csv file
            string path = "Student.csv";

            try
            {
                // Using StreamReader to open and read the csv file
                using (StreamReader read = new StreamReader(path))
                {
                    string line;
                    string header = read.ReadLine();

                    // Reading the file until the end
                    while ((line = read.ReadLine()) != null)
                    {
                        // Splitting the line by commas to extract individual columns
                        string[] columns = line.Split(',');

                        if(int.TryParse(columns[3], out int marks) && marks > 80)
                        {
                            //Displaying the extracted data in a formatted way
                            Console.WriteLine($"ID: {columns[0]}, Name: {columns[1]}, Age: {columns[2]}, Marks: {columns[3]}");
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
    }
}