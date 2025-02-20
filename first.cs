using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFile = "source.txt";   // Replace with your source file path
        string destinationFile = "destination.txt";  // Replace with your destination file path

        // Check if the source file exists
        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("The source file does not exist.");
            return;  // Exit the program if the file doesn't exist
        }

        // Ensure the destination file is created if it does not exist
        if (!File.Exists(destinationFile))
        {
            // Create an empty file if it does not exist
            using (FileStream fs = File.Create(destinationFile))
            {
                Console.WriteLine("Destination file created.");
            }
        }

        // Open the source file for reading
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        {
            // Open the destination file for writing
            using (FileStream destinationStream = new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                // Buffer for reading data from the source file
                byte[] buffer = new byte[1024];  // Adjust buffer size as needed
                int bytesRead;

                // Read from the source and write to the destination
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }

                Console.WriteLine("File has been copied successfully.");
            }
        }
    }
}
