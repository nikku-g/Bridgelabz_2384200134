using System;

public class QueueUsingStacks
{
    private int[] stack1;  // Stack used for enqueue
    private int[] stack2;  // Stack used for dequeue
    private int top1;      // Top index for stack1
    private int top2;      // Top index for stack2

    // Constructor to initialize the two stacks
    public QueueUsingStacks()
    {
        stack1 = new int[100];  // Arbitrary size for the stack (can be resized as needed)
        stack2 = new int[100];
        top1 = -1;  // stack1 is empty
        top2 = -1;  // stack2 is empty
    }

    // Enqueue: Push element to stack1
    public void Enqueue(int data)
    {
        if (top1 >= stack1.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }
        stack1[++top1] = data;  // Push element onto stack1
    }

    // Dequeue: Pop element from stack2, transfer elements from stack1 if needed
    public int Dequeue()
    {
        // If both stacks are empty, queue is empty
        if (top1 == -1 && top2 == -1)
        {
            Console.WriteLine("Queue is empty");
            return -1;  // Indicating empty queue
        }

        // If stack2 is empty, transfer elements from stack1 to stack2
        if (top2 == -1)
        {
            while (top1 >= 0)
            {
                stack2[++top2] = stack1[top1--];  // Move elements to stack2
            }
        }

        // Pop element from stack2
        return stack2[top2--];
    }

    // Peek: Get the front element without removing it
    public int Peek()
    {
        if (top1 == -1 && top2 == -1)
        {
            Console.WriteLine("Queue is empty");
            return -1;  // Indicating empty queue
        }

        // If stack2 is empty, transfer elements from stack1 to stack2
        if (top2 == -1)
        {
            while (top1 >= 0)
            {
                stack2[++top2] = stack1[top1--];  // Move elements to stack2
            }
        }

        // The element at the top of stack2 is the front of the queue
        return stack2[top2];
    }

    // Check if the queue is empty
    public bool IsEmpty()
    {
        return top1 == -1 && top2 == -1;
    }
}

public class Program
{
    public static void Main()
    {
        QueueUsingStacks queue = new QueueUsingStacks();

        // Enqueue elements
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("Front element (Peek): " + queue.Peek()); 
        // Dequeue elements
        Console.WriteLine("Dequeued: " + queue.Dequeue()); 
        Console.WriteLine("Dequeued: " + queue.Dequeue()); 

        // Enqueue more elements
        queue.Enqueue(40);
        queue.Enqueue(50);

        Console.WriteLine("Front element (Peek): " + queue.Peek()); 

        // Dequeue the remaining elements
        Console.WriteLine("Dequeued: " + queue.Dequeue()); 
        Console.WriteLine("Dequeued: " + queue.Dequeue()); 
        Console.WriteLine("Dequeued: " + queue.Dequeue()); 

        Console.WriteLine("Queue is empty: " + queue.IsEmpty()); 
    }
}
