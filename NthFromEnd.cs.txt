using System;
using System.Collections.Generic;

class Program
{
    static string FindNthFromEnd(LinkedList<string> list, int n)
    {
        LinkedListNode<string> first = list.First;
        LinkedListNode<string> second = list.First;
        
        // Move first pointer n steps ahead
        for (int i = 0; i < n; i++)
        {
            if (first == null) return "N is larger than the list size";
            first = first.Next;
        }
        
        // Move both pointers until first reaches the end
        while (first != null)
        {
            first = first.Next;
            second = second.Next;
        }
        
        return second.Value;
    }

    static void Main()
    {
        LinkedList<string> linkedList = new LinkedList<string>(new string[] { "A", "B", "C", "D", "E" });
        int n = 2;
        
        string result = FindNthFromEnd(linkedList, n);
        Console.WriteLine("Nth element from the end: " + result);
    }
}
