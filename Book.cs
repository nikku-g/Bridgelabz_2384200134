using System;

// Book class to represent library books
class Book
{
    // Static variable shared across all books
    public static string LibraryName = "City Central Library";
    
    // Readonly variable to ensure ISBN cannot be changed after initialization
    public readonly string ISBN;

    // Property to store the title of the book
    public string Title { get; }
    // Property to store the author of the book
    public string Author { get; }
    // Boolean property to check if the book is available or issued
    public bool IsAvailable { get; private set; } = true;

    // Constructor to initialize book details using 'this' keyword
    public Book(string title, string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    // Static method to display the library name
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
    }

    // Method to display book details with 'is' operator check
    public void DisplayBookDetails()
    {
        if (this is Book)
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Available: " + (IsAvailable ? "Yes" : "No"));
        }
        else
        {
            Console.WriteLine("Invalid book object.");
        }
    }

    // Main method to handle user interactions and library operations
    static void Main()
    {
        Console.WriteLine("Welcome to the Library!");
		
        // Allow user to update the library name at runtime
        Console.Write("Enter new Library Name: ");
        LibraryName = Console.ReadLine();
        
        // Display updated library name
        Book.DisplayLibraryName();

        // Create a book object
        Book book1 = null;

        // Boolean flag to control the menu loop
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Issue a Book");
            Console.WriteLine("2. Return a Book");
            Console.WriteLine("3. Check Availability of Book");
            Console.WriteLine("4. Penalty on the Book");
            Console.WriteLine("5. Update Library Name");
            Console.WriteLine("6. Exit");

            // Read user choice
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Taking book details from user for issuing
                    Console.Write("Enter the book title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter the author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter the ISBN: ");
                    string isbn = Console.ReadLine();
                    
                    book1 = new Book(title, author, isbn);
                    Console.Write("Enter the book title to issue: ");
                    string issuedBookTitle = Console.ReadLine();
                    
                    // Issuing the book according to the availability of the book
                    if (book1.IsAvailable)
                    {
                        book1.IsAvailable = false;
                        Console.WriteLine("Book issued successfully: " + book1.Title);
                    }
                    else
                    {
                        Console.WriteLine("Book is already issued.");
                    }
                    break;
                case "2":
                    // Taking book details from user for returning
                    Console.Write("Enter the book title to return: ");
                    string returnedBookTitle = Console.ReadLine();
                    
                    if (book1 != null && book1.Title.Equals(returnedBookTitle, StringComparison.OrdinalIgnoreCase))
                        book1.IsAvailable = true;
                        Console.WriteLine("Book returned successfully: " + book1.Title);
                    Console.WriteLine("Book returned successfully.");
                    break;
                case "3":
                    // Taking book details from user to check availability
                    Console.Write("Enter the book title to check availability: ");
                    string checkBookTitle = Console.ReadLine();
                    
                    if (book1 != null && book1.Title.Equals(checkBookTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        if (book1.IsAvailable)
                        {
                            Console.WriteLine("The book '" + book1.Title + "' is available.");
                        }
                        else
                        {
                            Console.WriteLine("The book '" + book1.Title + "' is currently issued.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    Console.Write("Enter the book title to check availability: ");
                    string checkBookTitle = Console.ReadLine();
                    
                    if (book1 != null && book1.Title.Equals(checkBookTitle, StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Book Availability: " + (book1.IsAvailable ? "Available" : "Not Available"));
                    break;
                case "4":
                    // Taking book details from user to check penalty
                    Console.Write("Enter the book title to check penalty: ");
                    string penaltyBookTitle = Console.ReadLine();
                    
                    if (book1 != null && book1.Title.Equals(penaltyBookTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!book1.IsAvailable)
                        {
                            Console.WriteLine("Penalty: $5 if the book '" + book1.Title + "' is returned late.");
                        }
                        else
                        {
                            Console.WriteLine("No penalty. The book is not overdue.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    
                    if (book1 != null && book1.Title.Equals(penaltyBookTitle, StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Penalty: $5 if the book '" + book1.Title + "' is returned late.");
                    break;
                case "5":
                    Console.Write("Enter new Library Name: ");
                    LibraryName = Console.ReadLine();
                    Console.WriteLine("Library name updated successfully.");
                    Book.DisplayLibraryName();
                    break;
                case "6":
                    exit = true;
                    // Exit message
                    Console.WriteLine("Exiting the system.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }
}