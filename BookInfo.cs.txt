using System;

// Base class: Book
class Book
{
    public string Title { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, int publicationYear)
    {
        Title = title;
        PublicationYear = publicationYear;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Title: {0}, Publication Year: {1}", Title, PublicationYear);
    }
}

// Subclass: Author
class Author : Book
{
    public string Name { get; set; }
    public string Bio { get; set; }

    public Author(string title, int publicationYear, string name, string bio) : base(title, publicationYear)
    {
        Name = name;
        Bio = bio;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Author: {0}, Bio: {1}", Name, Bio);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Author author = new Author("The Great Novel", 2021, "John Doe", "A renowned novelist.");
        author.DisplayInfo();
    }
}
