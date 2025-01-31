using System;

class ToggleCase
{
	// Creating a method to change the case of the string
    public static void ChangeCase()
    {
        // Take input string from user
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        // Initialize an empty string to store the result
        string result = "";

        // Loop through each character in the input string
        foreach (char ch in input)
        {
            // Check if the character is uppercase
            if (ch >= 'A' && ch <= 'Z')
            {
                // Convert to lowercase by adding 32 to its ASCII value
                result += (char)(ch + 32);
            }
            // Check if the character is lowercase
            else if (ch >= 'a' && ch <= 'z')
            {
                // Convert to uppercase by subtracting 32 from its ASCII value
                result += (char)(ch - 32);
            }
            else
            {
                // Keep non-alphabetic characters unchanged
                result += ch;
            }
        }

        // Output the result
        Console.WriteLine("Toggled case string: " + result);
    }
	
	public static void Main(string[] args)
	{
		// Calling the method
		ChangeCase();
	}	
}