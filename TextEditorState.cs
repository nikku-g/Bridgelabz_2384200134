using System;
using System.Collections.Generic;

public class TextEditorState
{
    public string Text { get; set; }

    public TextEditorState(string text)
    {
        Text = text;
    }
}

public class TextEditorUndoRedo
{
    public class Node
    {
        public TextEditorState Data;
        public Node Next;
        public Node Prev;

        public Node(TextEditorState data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node currentState;
    private int historySize = 10; // Maximum number of states stored in history
    private int currentSize = 0;

    private Node head;
    private Node tail;

    public TextEditorUndoRedo()
    {
        currentState = null;
        head = null;
        tail = null;
    }

    // Add a new text state
    public void AddState(string text)
    {
        TextEditorState newState = new TextEditorState(text);
        Node newNode = new Node(newState);

        // If there are already 10 states, remove the oldest (head)
        if (currentSize == historySize)
        {
            head = head.Next;
            if (head != null)
                head.Prev = null;
            currentSize--;
        }

        if (head == null) // No states yet
        {
            head = newNode;
            tail = newNode;
            currentState = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
            currentState = tail; // Move the current state to the latest added state
        }

        currentSize++;
    }

    // Undo functionality
    public void Undo()
    {
        if (currentState?.Prev != null)
        {
            currentState = currentState.Prev;
            Console.WriteLine("Undo: " + currentState.Data.Text);
        }
        else
        {
            Console.WriteLine("No more undo actions.");
        }
    }

    // Redo functionality
    public void Redo()
    {
        if (currentState?.Next != null)
        {
            currentState = currentState.Next;
            Console.WriteLine("Redo: " + currentState.Data.Text);
        }
        else
        {
            Console.WriteLine("No more redo actions.");
        }
    }

    // Display the current text state
    public void DisplayCurrentState()
    {
        if (currentState != null)
        {
            Console.WriteLine("Current State: " + currentState.Data.Text);
        }
        else
        {
            Console.WriteLine("No text state available.");
        }
    }

    // Set the maximum history size
    public void SetHistorySize(int size)
    {
        historySize = size;
    }

    // Display all states in the history (for debugging)
    public void DisplayHistory()
    {
        Node temp = head;
        Console.WriteLine("Text History:");
        while (temp != null)
        {
            Console.WriteLine(temp.Data.Text);
            temp = temp.Next;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TextEditorUndoRedo editor = new TextEditorUndoRedo();

        // Add some text states
        editor.AddState("Initial text.");
        editor.AddState("Added first sentence.");
        editor.AddState("Added second sentence.");
        editor.AddState("Changed the second sentence.");
        editor.AddState("Final version of the text.");

        // Display the current state
        editor.DisplayCurrentState(); // Should display: Final version of the text.

        // Undo and Redo operations
        editor.Undo(); // Should display: Changed the second sentence.
        editor.Undo(); // Should display: Added second sentence.
        editor.Redo(); // Should display: Changed the second sentence.
        editor.Redo(); // Should display: Final version of the text.

        // Add more text states to test history size limitation
        editor.AddState("New text after redo.");
        editor.AddState("Another update.");

        // Display all states in history
        editor.DisplayHistory();
    }
}
