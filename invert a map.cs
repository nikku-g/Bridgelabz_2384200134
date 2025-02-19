using System;
using System.Collections.Generic;

class Program
{
    // Method to invert a dictionary where values become keys and keys become values in a list
    public static Dictionary<V, List<K>> InvertDictionary<K, V>(Dictionary<K, V> originalDict)
    {
        // Create a new dictionary to store inverted key-value pairs
        Dictionary<V, List<K>> invertedDict = new Dictionary<V, List<K>>();

        // Loop through each key-value pair in the original dictionary
        foreach (var pair in originalDict)
        {
            V value = pair.Value;
            K key = pair.Key;

            // If the value already exists in the inverted dictionary, add the key to the list
            if (invertedDict.ContainsKey(value))
            {
                invertedDict[value].Add(key);
            }
            else
            {
                // Otherwise, create a new list with the current key
                invertedDict[value] = new List<K> { key };
            }
        }

        return invertedDict;
    }

    static void Main()
    {
        // Example input dictionary
        Dictionary<string, int> originalDict = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 }
        };

        // Inverting the dictionary
        var invertedDict = InvertDictionary(originalDict);

        // Display the inverted dictionary
        Console.WriteLine("Inverted Dictionary:");
        foreach (var pair in invertedDict)
        {
            Console.WriteLine($"{pair.Key} = [{string.Join(", ", pair.Value)}]");
        }
    }
}
