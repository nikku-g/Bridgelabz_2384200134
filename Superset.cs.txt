using System;
using System.Collections.Generic;

class Program
{
    static bool IsSubset(HashSet<int> subset, HashSet<int> superset)
    {
        return superset.IsSupersetOf(subset);
    }

    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 1, 2, 3, 4 };
        
        bool result = IsSubset(set1, set2);
        Console.WriteLine("Is subset? " + result);
    }
}
