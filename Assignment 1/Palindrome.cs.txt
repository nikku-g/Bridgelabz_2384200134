using System;

public class Palindrome
{
    public static void Main(string[] args)
    {
        // Prompt the user to enter a string
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Call the method to check if the string is a palindrome
        bool isPalindrome = IsPalindrome(input);

        // Print whether the string is a palindrome
        if (isPalindrome)
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }
    }

    // Method to check if the string is a palindrome
    public static bool IsPalindrome(string input)
    {
        // Convert input to lowercase to make the comparison case-insensitive
        input = input.ToLower();

        // Initialize two pointers, one at the start and one at the end of the string
        int start = 0;
        int end = input.Length - 1;

        // Loop to compare characters from both ends of the string
        while (start < end)
        {
            
                // Compare the characters at the start and end
                if (input[start] != input[end])
                {
                    return false; // Return false if they don't match
                }

                // Move the pointers towards the center
                start++;
                end--;
            
        }

        // Return true if the entire string was matched
        return true;
    }
}