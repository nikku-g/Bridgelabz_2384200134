using System;

public class ReverseString
{
    public static void Main(string[] args)
    {
        // Prompt the user to enter a string
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        // Call the method to reverse the string
        string reversedString = Reverse(input);

        // Print the reversed string
        Console.WriteLine($"Reversed String: {reversedString}");
    }

    // Method to reverse the string manually
    public static string Reverse(string input)
    {
        // Create a character array to store the reversed string
        char[] reversedArray = new char[input.Length];

        // Loop through the input string in reverse order
        int j = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedArray[j] = input[i]; // Copy characters from end to start
            j++;
        }

        // Convert the character array back to a string and return it
        return new string(reversedArray);
    }
}
