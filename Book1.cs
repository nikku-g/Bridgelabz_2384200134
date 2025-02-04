
using System;

class Book {
	public string ISBN; // public specifier
	protected string title; // protected specifier
	private string author; // private specifier
	
	public Book(string ISBN, string title, string author) {
		this.ISBN = ISBN;
		this.title = title;
		this.author = author;
	}
	
	// Method to get author
	public string getAuthor() {
		return author;
	}
	
	// Method to set author
	public void setAuthor(string newAuthor) {
		author = newAuthor;
	}
}

class EBook : Book {
	private double fileSize;
	
	public EBook(string ISBN, string title, string author, double fileSize) : base(ISBN, title, author) {
		this.fileSize = fileSize;
	}
	
	public void display() {
		Console.WriteLine("ISBN: {0}, title: {1}, author: {2}, fileSize: {3}", ISBN, title, getAuthor(), fileSize);
	}
}

class Program {
	public static void Main() {
		// Creating a book instance
		Book book1 = new Book("123-4567890123", "C# Programming", "John Doe");
        Console.WriteLine("Book ISBN: {0}, Author: {1}", book1.ISBN, book1.getAuthor());
        
        // Modifying author
        book1.setAuthor("Jane Smith");
        Console.WriteLine("Updated Author: {0}", book1.getAuthor());

        Console.WriteLine();

        // Creating an eBook instance
        EBook ebook1 = new EBook("987-6543210987", "Advanced C#", "Alice Johnson", 5.2);
        ebook1.display();
    }
}

