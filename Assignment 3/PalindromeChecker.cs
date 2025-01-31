using System;

class PalindromeChecker
{
    // Function to get input from the user
    static string GetInput()
    {
        Console.WriteLine("Enter a string to check if it's a palindrome:");
        return Console.ReadLine();
    }

    // Function to check if the string is a palindrome
    static bool IsPalindrome(string input)
    {
        // Remove any non-alphanumeric characters and convert to lowercase
        string cleanedInput = string.Concat(input.Where(char.IsLetterOrDigit)).ToLower();

        // Check if the cleaned string is the same forwards and backwards
        int left = 0, right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    // Function to display the result
    static void DisplayResult(string input, bool isPalindrome)
    {
        if (isPalindrome)
        {
            Console.WriteLine(input+" is a palindrome.");
        }
        else
        {
            Console.WriteLine(input+" is not a palindrome.");
        }
    }

    // Main function to drive the program
    static void Main(string[] args)
    {
        // Get the input string
        string userInput = GetInput();

        // Check if the string is a palindrome
        bool result = IsPalindrome(userInput);

        // Display the result
        DisplayResult(userInput, result);
    }
}
