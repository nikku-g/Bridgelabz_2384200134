using System;
using System.Text;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "user_input.txt"; // Change to desired file name
        
        ReadUserInputAndWriteToFile(filePath);
    }
    
    static void ReadUserInputAndWriteToFile(string filePath)
    {
        try
        {
            Console.WriteLine("Enter text to write to the file (type 'exit' to stop):");
            
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                string input;
                while ((input = Console.ReadLine()) != null && input.ToLower() != "exit")
                {
                    sw.WriteLine(input);
                }
            }
            
            Console.WriteLine("User input successfully written to the file.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing to file: {e.Message}");
        }
    }
}