using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> CountFrequencies(List<string> words)
    {
        Dictionary<string, int> frequencyDict = new Dictionary<string, int>();
        
        foreach (var word in words)
        {
            if (frequencyDict.ContainsKey(word))
                frequencyDict[word]++;
            else
                frequencyDict[word] = 1;
        }
        
        return frequencyDict;
    }

    static void Main()
    {
        List<string> words = new List<string> { "apple", "banana", "apple", "orange" };
        Dictionary<string, int> frequencies = CountFrequencies(words);
        
        foreach (var kvp in frequencies)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
