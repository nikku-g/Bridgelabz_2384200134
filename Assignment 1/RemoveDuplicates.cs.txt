using System;

public class RemoveDuplicates
{
    public static void Main(string[] args)
    {
        // Prompt the user to enter a string
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Call the method to remove duplicates and get the modified string
        string result = Remove(input);

        // Print the modified string
        Console.WriteLine($"String after removing duplicates: {result}");
    }

    // Method to remove duplicates from the string
    static string Remove(string input)
    {
        // Create a string to store the result
        string result = "";

        // Loop through each character in the input string
        foreach (char c in input)
        {
            // Track if the character is already in the result string
            bool isDuplicate = false;

            // Loop through the result string to check if the character already exists
            foreach (char r in result)
            {
                if (r == c)
                {
                    isDuplicate = true;
                    break;  // Exit the loop if a duplicate is found
                }
            }

            // If not a duplicate, add the character to the result string
            if (!isDuplicate)
            {
                result += c;
            }
        }

        // Return the result string without duplicates
        return result;
    }
}
