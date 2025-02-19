using System;
using System.Collections.Generic;

class Program
{
    static List<int> ConvertToSortedList(HashSet<int> set)
    {
        List<int> sortedList = new List<int>(set);
        sortedList.Sort();
        return sortedList;
    }

    static void Main()
    {
        HashSet<int> numbers = new HashSet<int> { 5, 3, 9, 1 };
        List<int> sortedList = ConvertToSortedList(numbers);
        
        Console.WriteLine("Sorted List: [ " + string.Join(", ", sortedList) + " ]");
    }
}
