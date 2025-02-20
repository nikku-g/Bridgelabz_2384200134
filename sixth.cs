using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";   // Path of the input file
        string outputFile = "output.txt"; // Path of the output file

        // Check if the input file exists before attempting to read it
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("The input file does not exist.");
            return;
        }

        // Proceed with file conversion if the input file exists
        if (ConvertFileToLowercase(inputFile, outputFile))
        {
            Console.WriteLine("File conversion completed. All uppercase letters have been converted to lowercase.");
        }
        else
        {
            Console.WriteLine("There was an issue processing the files.");
        }
    }

    // Method to convert file contents to lowercase
    static bool ConvertFileToLowercase(string inputFile, string outputFile)
    {
        // Verify if the output file's directory exists or is accessible
        string outputDirectory = Path.GetDirectoryName(outputFile);
        if (outputDirectory != null && !Directory.Exists(outputDirectory))
        {
            Console.WriteLine("Output file directory does not exist.");
            return false;
        }

        // Read and write contents while converting to lowercase using StreamReader and StreamWriter with BufferedStream
        FileStream inputStream = null;
        FileStream outputStream = null;
        BufferedStream bufferedInputStream = null;
        BufferedStream bufferedOutputStream = null;
        StreamReader reader = null;
        StreamWriter writer = null;

        // Open the input file and output file
        inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
        bufferedInputStream = new BufferedStream(inputStream);
        reader = new StreamReader(bufferedInputStream, Encoding.UTF8);

        outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
        bufferedOutputStream = new BufferedStream(outputStream);
        writer = new StreamWriter(bufferedOutputStream, Encoding.UTF8);

        string line;

        // Read each line from the input file and convert to lowercase
        while ((line = reader.ReadLine()) != null)
        {
            string lowerCaseLine = line.ToLower();  // Convert line to lowercase
            writer.WriteLine(lowerCaseLine);  // Write the converted line to output file
        }

        // Close the streams
        reader.Close();
        writer.Close();
        bufferedInputStream.Close();
        bufferedOutputStream.Close();
        inputStream.Close();
        outputStream.Close();

        return true;
    }
}
