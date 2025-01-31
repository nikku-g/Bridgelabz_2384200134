using System;

class WordReplacer
{
    public static void Main(string[] args)
    {
        // Take input sentence from the user
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        // Take the word to replace and the replacement word from the user
        Console.WriteLine("Enter the word to replace:");
        string wordToReplace = Console.ReadLine();

        Console.WriteLine("Enter the replacement word:");
        string replacementWord = Console.ReadLine();

        // Call the ReplaceWord method to perform the replacement
        string result = ReplaceWord(sentence, wordToReplace, replacementWord);

        // Output the result
        Console.WriteLine("Updated sentence: " + result);
    }

    // Method to replace a given word with another in a sentence
    static string ReplaceWord(string sentence, string wordToReplace, string replacementWord)
    {
        // Initialize variables to store the result
        string result = "";
        int i = 0;
        int wordLength = wordToReplace.Length;
        
        // Traverse the sentence one character at a time
        while (i < sentence.Length)
        {
            // Check if the current substring matches the word to replace
            bool match = true;
            for (int j = 0; j < wordLength; j++)
            {
                if (i + j >= sentence.Length || sentence[i + j] != wordToReplace[j])
                {
                    match = false;
                    break;
                }
            }

            // If the word matches, append the replacement word to result
            if (match)
            {
                result += replacementWord;
                i += wordLength; // Skip past the word we just replaced
            }
            else
            {
                result += sentence[i];
                i++; // Move to the next character
            }
        }

        // Return the modified sentence
        return result;
    }
}