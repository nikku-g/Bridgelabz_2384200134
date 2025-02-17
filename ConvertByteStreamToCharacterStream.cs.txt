using System;
using System.Text;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "sample.bin"; // Change to your binary file
        
        ConvertByteStreamToCharacterStream(filePath);
    }
    
    static void ConvertByteStreamToCharacterStream(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                string content = sr.ReadToEnd();
                Console.WriteLine("File content as characters:");
                Console.WriteLine(content);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
    }
}