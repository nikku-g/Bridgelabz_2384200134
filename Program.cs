using System;
using System.Collections.Generic;

// Define the Book class
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

     public override string ToString()
    {
        return $"'{Title}' Written by {Author}";
    }
}

// Define the Library class
class Library
{
    public string LibraryName { get; set; }
    public List<Book> Books { get; set; }

    public Library(string name)
    {
        LibraryName = name;
        Books = new List<Book>();
    }

    // Method to add a book to the library
    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    // Method to display books in the library
    public void DisplayBooks()
    {
        Console.WriteLine($"Books in {LibraryName}:");
        if (Books.Count == 0)
        {
            Console.WriteLine("No books available in this library.");
        }
        else
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"- {book}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create book objects
        Book book1 = new Book("1984", "George Orwell");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee");
        Book book3 = new Book("Pride and Prejudice", "Jane Austen");

        // Create library objects
        Library library1 = new Library("City Library");
        Library library2 = new Library("Central Library");

        // Add books to libraries
        library1.AddBook(book1);
        library1.AddBook(book2);

        library2.AddBook(book2);
        library2.AddBook(book3);

        // Display books in each library
        library1.DisplayBooks();
        library2.DisplayBooks();
		
		// Display books in each library
        book1.Display();

        // A book can exist independently (outside of a library)
        Console.WriteLine("\nIndependent book:");
        Console.WriteLine(book1);  // Book1 exists independently of any library
    }
}
