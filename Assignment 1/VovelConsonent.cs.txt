using System;

public class VowelsConsonants
{
    public static void Main(string[] args)
    {
        // Prompt the user to enter a string
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        // Call the method to count vowels and consonants
        Count(input);
    }

    // Method to count vowels and consonants
    public static void Count(string input)
    {
        int vowelCount = 0;      // Initialize vowel count to 0
        int consonantCount = 0;  // Initialize consonant count to 0

        // Convert input to lowercase to make the comparison case-insensitive
        input = input.ToLower();

        // Loop through each character in the input string
        foreach (char c in input)
        {
            // Check if the character is a letter
            if (c >= 'a' && c <= 'z')
            {
                // Check if the character is a vowel
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    vowelCount++;  // Increment vowel count if it's a vowel
                }
                else
                {
                    consonantCount++;  // Increment consonant count if it's not a vowel
                }
            }
        }

        // Print the total count of vowels and consonants
        Console.WriteLine($"Vowels: {vowelCount}");
        Console.WriteLine($"Consonants: {consonantCount}");
    }
}