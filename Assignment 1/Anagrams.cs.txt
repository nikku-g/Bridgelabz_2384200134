using System;

class Anagrams
{
    public static void Main()
    {
        // Prompt user for the first string
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine().ToLower();
        
        // Prompt user for the second string
        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine().ToLower();
        
        // Check if the strings are anagrams and display the result
        if (AreAnagrams(str1, str2))
            Console.WriteLine("The strings are anagrams.");
        else
            Console.WriteLine("The strings are not anagrams.");
    }

    static bool AreAnagrams(string str1, string str2)
    {
        // If lengths are different, they can't be anagrams
        if (str1.Length != str2.Length)
            return false;
        
        int[] charCount = new int[26]; // Array to store letter counts (assuming only lowercase English letters)

        // Iterate through each character of both strings
        for (int i = 0; i < str1.Length; i++)
        {
            // Increment count for characters in str1
            charCount[str1[i] - 'a']++;
            // Decrement count for characters in str2
            charCount[str2[i] - 'a']--;
        }
        
        // Check if all character counts are zero
        foreach (int count in charCount)
        {
            if (count != 0)
                return false;
        }
        
        return true; // Strings are anagrams
    }
}
