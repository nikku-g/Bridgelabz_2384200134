using System;
using System.Collections.Generic;

// Interface for reservable items
public interface IReservable
{
    void ReserveItem(string borrowerName);
    bool CheckAvailability();
}

// Abstract class representing a Library Item
public abstract class LibraryItem : IReservable
{
    protected string itemId;
    protected string title;
    protected string author;
    private string borrower; // Encapsulated borrower details
    protected bool isAvailable = true;

    // Constructor to initialize library item details
    public LibraryItem(string itemId, string title, string author)
    {
        this.itemId = itemId;
        this.title = title;
        this.author = author;
    }

    // Abstract method for loan duration
    public abstract int GetLoanDuration();

    // Concrete method to get item details
    public void GetItemDetails()
    {
        Console.WriteLine($"Item ID: {itemId}\nTitle: {title}\nAuthor: {author}\nLoan Duration: {GetLoanDuration()} days\nAvailability: {(isAvailable ? "Available" : "Not Available")}\n");
    }

    // Implementing reservation method
    public void ReserveItem(string borrowerName)
    {
        if (isAvailable)
        {
            borrower = borrowerName;
            isAvailable = false;
            Console.WriteLine($"Item '{title}' reserved by {borrower}.");
        }
        else
        {
            Console.WriteLine($"Item '{title}' is not available for reservation.");
        }
    }

    // Implementing availability check
    public bool CheckAvailability()
    {
        return isAvailable;
    }
}

// Book class inheriting from LibraryItem
public class Book : LibraryItem
{
    public Book(string itemId, string title, string author)
        : base(itemId, title, author) { }

    public override int GetLoanDuration()
    {
        return 14; // Books can be borrowed for 14 days
    }
}

// Magazine class inheriting from LibraryItem
public class Magazine : LibraryItem
{
    public Magazine(string itemId, string title, string author)
        : base(itemId, title, author) { }

    public override int GetLoanDuration()
    {
        return 7; // Magazines can be borrowed for 7 days
    }
}

// DVD class inheriting from LibraryItem
public class DVD : LibraryItem
{
    public DVD(string itemId, string title, string author)
        : base(itemId, title, author) { }

    public override int GetLoanDuration()
    {
        return 5; // DVDs can be borrowed for 5 days
    }
}

// Main program class
internal class Program
{
    public static void Main(string[] args)
    {
        // List to store library items
        List<LibraryItem> libraryItems = new List<LibraryItem>
        {
            new Book("B001", "The Great Gatsby", "F. Scott Fitzgerald"),
            new Magazine("M002", "National Geographic", "Various"),
            new DVD("D003", "Inception", "Christopher Nolan"),
        };

        // Display details and perform operations
        foreach (var item in libraryItems)
        {
            item.GetItemDetails();
        }

        // Reserving an item
        libraryItems[0].ReserveItem("Vanshita Khantal");
        libraryItems[0].GetItemDetails();
    }
}