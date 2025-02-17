using System;
using System.Text;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "sample.txt";
        
        ReadFileLineByLine(filePath);
    }
    
    static void ReadFileLineByLine(string filePath)
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
    }
}