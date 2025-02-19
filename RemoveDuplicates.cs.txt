using System;
using System.Collections.Generic;

class Program
{
    static List<int> RemoveDuplicates(List<int> numbers)
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> uniqueNumbers = new List<int>();
        
        foreach (int num in numbers)
        {
            if (!seen.Contains(num))
            {
                seen.Add(num);
                uniqueNumbers.Add(num);
            }
        }
        
        return uniqueNumbers;
    }

    static void Main()
    {
        List<int> numbers = new List<int> { 3, 1, 2, 2, 3, 4 };
        List<int> uniqueList = RemoveDuplicates(numbers);
        Console.WriteLine("List after removing duplicates: " + string.Join(", ", uniqueList));
    }
}
