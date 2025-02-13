using System;

class CustomStack
{
    private int[] stack;
    private int top;
    private int capacity;

    // Constructor to initialize the stack
    public CustomStack(int size)
    {
        capacity = size;
        stack = new int[capacity];
        top = -1;
    }

    // Function to push an element
    public void Push(int item)
    {
        if (top == capacity - 1)
        {
            Console.WriteLine("Stack Overflow! Cannot push more items.");
            return;
        }
        stack[++top] = item;
    }

    // Function to pop an element
    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack Underflow! No items to pop.");
            return -1; // Indicating error
        }
        return stack[top--];
    }

    // Function to peek the top element
    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty!");
            return -1;
        }
        return stack[top];
    }

    // Function to check if stack is empty
    public bool IsEmpty()
    {
        return top == -1;
    }

    // Function to display the stack
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty.");
            return;
        }
        Console.WriteLine("Stack elements (Top to Bottom):");
        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine(stack[i]);
        }
    }

    // Recursive function to sort the stack
    public void SortStack()
    {
        if (!IsEmpty())
        {
            // Remove the top element
            int temp = Pop();

            // Sort the remaining stack
            SortStack();

            // Insert the element back at the correct position
            InsertSorted(temp);
        }
    }

    // Recursive function to insert an element at its correct position
    private void InsertSorted(int element)
    {
        // If stack is empty or element is greater than top
        if (IsEmpty() || Peek() >= element)
        {
            Push(element);
            return;
        }

        // Remove top element
        int temp = Pop();

        // Recursively insert the element
        InsertSorted(element);

        // Push back the removed element
        Push(temp);
    }
}

// Main program to test the sorting of stack
class Program
{
    static void Main()
    {
        CustomStack stack = new CustomStack(10);

        stack.Push(30);
        stack.Push(10);
        stack.Push(50);
        stack.Push(20);
        stack.Push(40);

        Console.WriteLine("Original Stack:");
        stack.Display();

        stack.SortStack();

        Console.WriteLine("\nSorted Stack:");
        stack.Display();
    }
}
