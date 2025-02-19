using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example input list of strings
        List<string> inputList = new List<string> { "apple", "banana", "apple", "orange" };

        // Get the frequency of elements in the list
        Dictionary<string, int> frequencyDictionary = GetFrequency(inputList);

        // Output the results
        Console.WriteLine("Frequency of elements:");
        foreach (var item in frequencyDictionary)
        {
            Console.WriteLine($"\"{item.Key}\": {item.Value}");
        }
    }

    // Method to get the frequency of elements in the list
    static Dictionary<string, int> GetFrequency(List<string> list)
    {
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        foreach (string item in list)
        {
            // If the item is already in the dictionary, increment its frequency
            if (frequency.ContainsKey(item))
            {
                frequency[item]++;
            }
            else
            {
                // If the item is not in the dictionary, add it with frequency 1
                frequency[item] = 1;
            }
        }

        return frequency;
    }
}
