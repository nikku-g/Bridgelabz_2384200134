using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class WordFrequencyCounter
{
    // Method to count word frequencies in a text file
    public static Dictionary<string, int> CountWordFrequencies(string filePath)
    {
        // Dictionary to store the frequency of each word
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        try
        {
            // Read the entire text file content
            string text = File.ReadAllText(filePath);

            // Convert text to lowercase to make the counting case-insensitive
            text = text.ToLower();

            // Use regex to remove non-alphanumeric characters (including punctuation)
            text = Regex.Replace(text, @"[^a-z\s]", "");

            // Split the text into words based on whitespace
            string[] words = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Count the frequency of each word
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return wordCount;
    }

    // Method to display word frequencies
    public static void DisplayWordFrequencies(Dictionary<string, int> wordCount)
    {
        Console.WriteLine("Word Frequencies:");
        foreach (var entry in wordCount)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    static void Main()
    {
        // Specify the path of the text file (change this to the path of your file)
        string filePath = "sample.txt";

        // Count word frequencies from the file
        Dictionary<string, int> wordCount = CountWordFrequencies(filePath);

        // Display the word frequencies
        DisplayWordFrequencies(wordCount);
    }
}
