
using System;

class BorrowBook
{
    private string title;
    private string author;
    private double price;
    private bool isAvailable;

    // Constructor to initialize book details
    public BorrowBook(string title, string author, double price, bool isAvailable = true)
    {
        this.title = title;
        this.author = author;
        this.price = price;
        this.isAvailable = isAvailable;
    }

    // Method to borrow a book
    public void Book()
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine("You have successfully borrowed '{0}' by {1}.", title, author);
        }
        else
        {
            Console.WriteLine("Sorry, '{0}' is currently not available.", title);
        }
    }

    // Method to display book details
    public void Display()
    {
        Console.WriteLine("Title: {0}, Author: {1}, Price: Rs.{2}, Available: {3}", title, author, price, isAvailable);
    }
}

class Program
{
    public static void Main()
    {
        // Creating a book instance
        BorrowBook book1 = new BorrowBook("1984", "George Orwell", 1115.99);
        
        // Display book details
        Console.WriteLine("Book Details:");
        book1.Display();
        
        Console.WriteLine();

        // Borrowing the book
        book1.Book();
        
        Console.WriteLine();

        // Attempt to borrow the book again
        book1.Book();
    }
}

