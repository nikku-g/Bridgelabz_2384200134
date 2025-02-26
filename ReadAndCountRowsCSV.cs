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
                int count = 1;
                // Using StreamReader to open and read the csv file
                using (StreamReader read = new StreamReader(path))
                {
                    string header = read.ReadLine();
                    // Reading the file until the end
                    while ((read.ReadLine()) != null)
                    {
                        // Increment the count
                        count++;
                    }
                }

                // Displaying the number of counts
                Console.WriteLine($"Total number of counts: {count}");
            }

            catch (Exception ex)
            {
                // Handling exceptions, such as file not found or access issues

                Console.WriteLine(ex.Message);
            }
        }
    }
}