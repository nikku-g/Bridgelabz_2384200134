using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "textfile.txt"; // Path of the file

        // Check if the file exists before attempting to read
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        // Count words in the file and display top 5 frequent words
        CountWordsInFile(filePath);
    }

    // Method to count words in a file and display the top 5 most frequent words
    static void CountWordsInFile(string filePath)
    {
        // Initialize a dictionary to store word counts
        Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // Open the file for reading using StreamReader
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Split the line into words (splitting by spaces and removing punctuation)
                string[] words = line.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    // Normalize the word by converting to lowercase and removing punctuation
                    string cleanedWord = new string(word.Where(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)).ToArray()).ToLower();

                    if (!string.IsNullOrEmpty(cleanedWord))
                    {
                        // Increment the word count in the dictionary
                        if (wordCount.ContainsKey(cleanedWord))
                        {
                            wordCount[cleanedWord]++;
                        }
                        else
                        {
                            wordCount[cleanedWord] = 1;
                        }
                    }
                }
            }
        }

        // Sort the dictionary by word frequency in descending order
        var sortedWordCount = wordCount.OrderByDescending(kv => kv.Value).Take(5);

        // Display the top 5 most frequent words
        Console.WriteLine("Top 5 most frequent words:");
        foreach (var entry in sortedWordCount)
        {
            Console.WriteLine($"Word: '{entry.Key}', Frequency: {entry.Value}");
        }
    }
}
