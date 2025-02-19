using System;
using System.Collections.Generic;

class ReverseQueue
{
    // Method to reverse a queue using recursion
    public static void ReverseQueueUsingRecursion(Queue<int> queue)
    {
        // Base case: If the queue is empty, return
        if (queue.Count == 0)
        {
            return;
        }

        // Recursive case: Dequeue the front element
        int front = queue.Dequeue();

        // Reverse the remaining queue
        ReverseQueueUsingRecursion(queue);

        // Enqueue the dequeued element back into the queue
        queue.Enqueue(front);
    }

    static void Main()
    {
        // Create and populate the queue with example elements
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("Original Queue:");
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }

        // Reverse the queue using the recursive method
        ReverseQueueUsingRecursion(queue);

        Console.WriteLine("\nReversed Queue:");
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }
    }
}
