using System;

class SubstringOccurence
{
    static void Main()
    {
        Console.WriteLine("Enter the main string:");
        string mainString = Console.ReadLine();
        
        Console.WriteLine("Enter the substring to search for:");
        string substring = Console.ReadLine();

        int count = 0;
        int mainLength = mainString.Length;
        int subLength = substring.Length;

        // Loop through the main string
        for (int i = 0; i <= mainLength - subLength; i++)
        {
            bool matchFound = true;

            // Check if substring matches starting from the current position
            for (int j = 0; j < subLength; j++)
            {
                if (mainString[i + j] != substring[j])
                {
                    matchFound = false;
                    break;
                }
            }

            // If a match is found, increment the count
            if (matchFound)
            {
                count++;
            }
        }

        Console.WriteLine("The substring occurs "+count+" times.");
    }
}
