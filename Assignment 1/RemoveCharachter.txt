using System;

public class RemoveCharachter
{
    public static void Main(string[] args)
    {
	
	    // Prompt the user to enter a string
        Console.Write("Enter a string: ");
        string inputStr = Console.ReadLine();

        // Prompt the user to enter the character to remove
        Console.Write("Enter the character to remove: ");
        char charToRemove = Console.ReadKey().KeyChar;
        Console.WriteLine();

        // Remove the character by using an array
        string newStr = RemoveChar(inputStr, charToRemove);

        // Display the results
        Console.WriteLine($"\nOriginal String: {inputStr}");
        Console.WriteLine($"Character to Remove: '{charToRemove}'");
        Console.WriteLine($"Modified String: {newStr}");
		
    }
	
    public static string RemoveChar(string input, char character)
    {
        // Create a result array 
        char[] result = new char[input.Length];
        int index = 0;

        // Loop through the input string and copy characters that are not the one to remove
        foreach (char c in input)
        {
            if (c != character)
            {
                result[index++] = c;
            }
        }

        // Return a new string that contains only the characters that weren't removed
        return new string(result, 0, index);
    }
}