
using System;

class Book {
	
	private string title {get; set;}
	private string author {get; set;}
	private float price {get; set;}

	// Default Constructor //
	public Book() {
		title = "This is a title of the book";
		author = "Author";
		price = 200f;
	}

	// Parameterized Constructor //
	public Book(string title, string author, float price) {
		this.title = title;
		this.author = author;
		this.price = price;
	}

	public static void Main(string[] args) {
		Book book = new Book("Good Books", "Richard", 345f);
		Console.WriteLine("Title: {0}, Author: {1}, Price: {2}", book.title, book.author, book.price);
		Console.ReadLine();
	}
}

