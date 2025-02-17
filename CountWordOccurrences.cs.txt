using System;
using System.Text;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "sample.txt";
        string wordToCount = "example"; // Change this to the word you want to count
        
        int count = CountWordOccurrences(filePath, wordToCount);
        Console.WriteLine($"The word '{wordToCount}' appears {count} times in the file.");
    }
    
    static int CountWordOccurrences(string filePath, string word)
    {
        int count = 0;
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', '\t', '\r', '\n', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string w in words)
                    {
                        if (w.Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
        return count;
    }
}