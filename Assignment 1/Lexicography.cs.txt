using System;

class Lexicography
{
    static void Main()
    {
        // Prompt user for the first string
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();
        
        // Prompt user for the second string
        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();
        
        // Compare the strings lexicographically
        int result = LexicographicalCompare(str1, str2);
        
        // Display result
        if (result < 0)
            Console.WriteLine($"\"{str1}\" comes before \"{str2}\" in lexicographical order");
        else if (result > 0)
            Console.WriteLine($"\"{str1}\" comes after \"{str2}\" in lexicographical order");
        else
            Console.WriteLine("Both strings are equal.");
    }

    static int LexicographicalCompare(string str1, string str2)
    {
        int length = Math.Min(str1.Length, str2.Length);
        
        for (int i = 0; i < length; i++)
        {
            if (str1[i] < str2[i])
                return -1;
            else if (str1[i] > str2[i])
                return 1;
        }
        
        // If one string is a prefix of the other
        if (str1.Length < str2.Length)
            return -1;
        else if (str1.Length > str2.Length)
            return 1;
        
        return 0; // Both strings are equal
    }
}
