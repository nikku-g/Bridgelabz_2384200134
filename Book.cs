using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int BookID { get; set; }
    public bool AvailabilityStatus { get; set; } // true for available, false for borrowed

    public Book(string title, string author, string genre, int bookID, bool availabilityStatus)
    {
        Title = title;
        Author = author;
        Genre = genre;
        BookID = bookID;
        AvailabilityStatus = availabilityStatus;
    }
}


public class Node
{
    public Book Data;
    public Node Next;
    public Node Prev;

    public Node(Book data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}


public class Library
{
    private Node head;
    private Node tail;
    private int count;

    public Library()
    {
        head = null;
        tail = null;
        count = 0;
    }

    // Add a new book at the beginning
    public void AddAtBeginning(Book book)
    {
        Node newNode = new Node(book);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        count++;
    }

    // Add a new book at the end
    public void AddAtEnd(Book book)
    {
        Node newNode = new Node(book);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        count++;
    }

    // Add a new book at a specific position
    public void AddAtPosition(Book book, int position)
    {
        if (position < 0 || position > count)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        if (position == 0)
        {
            AddAtBeginning(book);
            return;
        }

        if (position == count)
        {
            AddAtEnd(book);
            return;
        }

        Node newNode = new Node(book);
        Node temp = head;
        for (int i = 0; i < position - 1; i++)
        {
            temp = temp.Next;
        }

        newNode.Next = temp.Next;
        newNode.Prev = temp;
        temp.Next.Prev = newNode;
        temp.Next = newNode;

        count++;
    }

    // Remove a book by Book ID
    public void RemoveByBookID(int bookID)
    {
        if (head == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.BookID == bookID)
            {
                if (temp.Prev != null) temp.Prev.Next = temp.Next;
                if (temp.Next != null) temp.Next.Prev = temp.Prev;

                if (temp == head) head = temp.Next;
                if (temp == tail) tail = temp.Prev;

                count--;
                Console.WriteLine($"Book with ID {bookID} has been removed.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Book not found.");
    }

    // Search for a book by Book Title or Author
    public void SearchBook(string searchTerm)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
                temp.Data.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Book found: {temp.Data.Title}, Author: {temp.Data.Author}, ID: {temp.Data.BookID}, Status: {(temp.Data.AvailabilityStatus ? "Available" : "Borrowed")}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Book not found.");
    }

    // Update a book’s Availability Status by Book ID
    public void UpdateAvailabilityStatus(int bookID, bool availabilityStatus)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.BookID == bookID)
            {
                temp.Data.AvailabilityStatus = availabilityStatus;
                Console.WriteLine($"Book with ID {bookID} availability status updated to {(availabilityStatus ? "Available" : "Borrowed")}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Book not found.");
    }

    // Display all books in forward order
    public void DisplayBooksForward()
    {
        if (head == null)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Node temp = head;
        Console.WriteLine("Books in the library (Forward Order):");
        while (temp != null)
        {
            Console.WriteLine($"ID: {temp.Data.BookID}, Title: {temp.Data.Title}, Author: {temp.Data.Author}, Genre: {temp.Data.Genre}, Status: {(temp.Data.AvailabilityStatus ? "Available" : "Borrowed")}");
            temp = temp.Next;
        }
    }

    // Display all books in reverse order
    public void DisplayBooksReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Node temp = tail;
        Console.WriteLine("Books in the library (Reverse Order):");
        while (temp != null)
        {
            Console.WriteLine($"ID: {temp.Data.BookID}, Title: {temp.Data.Title}, Author: {temp.Data.Author}, Genre: {temp.Data.Genre}, Status: {(temp.Data.AvailabilityStatus ? "Available" : "Borrowed")}");
            temp = temp.Prev;
        }
    }

    // Count the total number of books in the library
    public void CountBooks()
    {
        Console.WriteLine($"Total number of books in the library: {count}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Add some books to the library
        library.AddAtEnd(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 101, true));
        library.AddAtEnd(new Book("1984", "George Orwell", "Dystopian", 102, true));
        library.AddAtBeginning(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 100, true));

        // Display all books in forward and reverse order
        library.DisplayBooksForward();
        Console.WriteLine();
        library.DisplayBooksReverse();

        // Count the total number of books
        library.CountBooks();

        // Update availability status of a book
        library.UpdateAvailabilityStatus(101, false);

        // Search for a book by title
        library.SearchBook("1984");

        // Remove a book by Book ID
        library.RemoveByBookID(102);

        // Display books after removal
        Console.WriteLine("\nBooks after removal:");
        library.DisplayBooksForward();

        // Add a book at a specific position
        library.AddAtPosition(new Book("Moby Dick", "Herman Melville", "Adventure", 103, true), 1);
        Console.WriteLine("\nBooks after adding at position 1:");
        library.DisplayBooksForward();
    }
}
