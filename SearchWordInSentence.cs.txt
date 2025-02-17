using System;

class Program
{
    static void Main()
    {
        string[] sentences = {
            "The quick brown fox jumps over the lazy dog.",
            "C# is a powerful programming language.",
            "I love solving coding problems.",
            "Learning algorithms is fun!"
        };
        
        string wordToSearch = "coding";
        string result = FindSentenceContainingWord(sentences, wordToSearch);
        
        if (result != null)
        {
            Console.WriteLine($"First sentence containing '{wordToSearch}': {result}");
        }
        else
        {
            Console.WriteLine($"No sentence contains the word '{wordToSearch}'.");
        }
    }
    
    static string FindSentenceContainingWord(string[] sentences, string word)
    {
        foreach (string sentence in sentences)
        {
            if (sentence.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return sentence;
            }
        }
        return null; // Return null if no sentence contains the word
    }
}