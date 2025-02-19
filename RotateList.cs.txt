using System;
using System.Collections.Generic;

class Program
{
    static List<int> RotateList(List<int> numbers, int positions)
    {
        int n = numbers.Count;
        positions = positions % n; // Ensure rotation doesn't exceed list size
        
        List<int> rotated = new List<int>();
        rotated.AddRange(numbers.GetRange(positions, n - positions));
        rotated.AddRange(numbers.GetRange(0, positions));
        
        return rotated;
    }

    static void Main()
    {
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
        int rotateBy = 2;
        
        List<int> rotatedList = RotateList(numbers, rotateBy);
        Console.WriteLine("Rotated List: " + string.Join(", ", rotatedList));
    }
}
