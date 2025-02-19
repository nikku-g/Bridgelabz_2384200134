using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    // Method to reverse an ArrayList
    static void ReverseArrayList(ArrayList list)
    {
        int left = 0, right = list.Count - 1;
        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;
            left++;
            right--;
        }
    }

    // Method to reverse a LinkedList
    static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
    {
        LinkedList<int> reversedList = new LinkedList<int>();
        foreach (int item in list)
        {
            reversedList.AddFirst(item);
        }
        return reversedList;
    }

    static void Main()
    {
        // ArrayList example
        ArrayList arrayList = new ArrayList() { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original ArrayList: " + string.Join(", ", arrayList.ToArray()));
        ReverseArrayList(arrayList);
        Console.WriteLine("Reversed ArrayList: " + string.Join(", ", arrayList.ToArray()));
        
        // LinkedList example
        LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("Original LinkedList: " + string.Join(", ", linkedList));
        linkedList = ReverseLinkedList(linkedList);
        Console.WriteLine("Reversed LinkedList: " + string.Join(", ", linkedList));
    }
}
