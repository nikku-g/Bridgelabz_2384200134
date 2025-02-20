using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "largefile.txt"; // Path of the large file

        // Check if the file exists before attempting to read
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        // Read the file line by line and process it
        ReadFileLineByLine(filePath);
    }

    // Method to read the file line by line and display lines containing "error"
    static void ReadFileLineByLine(string filePath)
    {
        // Open the file for reading using StreamReader
        StreamReader reader = new StreamReader(filePath);

        string line;
        
        // Read each line from the file
        while ((line = reader.ReadLine()) != null)
        {
            // Check if the line contains the word "error" (case insensitive)
            if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine(line); // Print the line containing "error"
            }
        }

        // Close the StreamReader after reading the file
        reader.Close();
    }
}
