using System;

class MostFrequentCharacter
{
    public static void Main(string[] args)
    {
        // Take input string from the user
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        // Call the method to find the most frequent character
        char mostFrequentChar = FindMostFrequentCharacter(input);

        // Output the result
        Console.WriteLine("Most Frequent Character: '" + mostFrequentChar + "'");
    }

    static char FindMostFrequentCharacter(string input)
    {
        // Create an array to store frequency of each character
        int[] frequency = new int[256]; // Assuming extended ASCII characters

        // Loop through each character in the string
        foreach (char ch in input)
        {
            frequency[ch]++;
        }

        // Find the character with the highest frequency
        int maxCount = 0;
        char mostFrequentChar = '\0'; // Default to null character

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] > maxCount)
            {
                maxCount = frequency[i];
                mostFrequentChar = (char)i;
            }
        }

        return mostFrequentChar;
    }
}