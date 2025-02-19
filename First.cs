using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    // Method to reverse an ArrayList
    static void ReverseArrayList(ArrayList list)
    {
        int start = 0;
        int end = list.Count - 1;

        while (start < end)
        {
            // Swap the elements
            object temp = list[start];
            list[start] = list[end];
            list[end] = temp;

            start++;
            end--;
        }
    }

    // Method to print the list
    static void PrintList(ArrayList list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
	
	
	// Method to reverse a LinkedList
    static void ReverseLinkedList(LinkedList<int> list)
    {
        LinkedListNode<int> current = list.First;
        LinkedList<int> reversedList = new LinkedList<int>();

        while (current != null)
        {
            // Add the current node value to the front of the reversed list
            reversedList.AddFirst(current.Value);
            current = current.Next;
        }

        // Clear the original list and copy the reversed list
        list.Clear();
        foreach (var item in reversedList)
        {
            list.AddLast(item);
        }
    }

    // Method to print the LinkedList
    static void PrintLinkedList(LinkedList<int> list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
	
	static void Main()
    {
        // Example ArrayList
        ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };

        Console.WriteLine("Original ArrayList:");
        PrintList(list);

        // Reverse the ArrayList manually
        ReverseArrayList(list);

        Console.WriteLine("Reversed ArrayList:");
        PrintList(list);
		
		 // Example LinkedList
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);

        Console.WriteLine("Original LinkedList:");
        PrintLinkedList(list);

        // Reverse the LinkedList manually
        ReverseLinkedList(list);

        Console.WriteLine("Reversed LinkedList:");
        PrintLinkedList(list);
    }
}
