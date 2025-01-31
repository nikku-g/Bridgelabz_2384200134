using System;

class LargestWord
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        string longestWord = "";
        string currentWord = "";
        int maxLength = 0;

        // Traverse through each character in the sentence
        for (int i = 0; i < sentence.Length; i++)
        {
            char currentChar = sentence[i];

            // If the current character is not a space, build the current word
            if (currentChar != ' ')
            {
                currentWord += currentChar;
            }
            else
            {
                // If we reach a space, check if the current word is longer than the previous longest word
                if (currentWord.Length > maxLength)
                {
                    maxLength = currentWord.Length;
                    longestWord = currentWord;
                }
                // Reset current word for next word
                currentWord = "";
            }
        }

        // Check the last word in case the sentence does not end with a space
        if (currentWord.Length > maxLength)
        {
            longestWord = currentWord;
        }

        Console.WriteLine("The longest word is: " + longestWord);
    }
}
