using System;
using System.Collections.Generic;

namespace Generics
{
    // Abstract base class representing a general category
    abstract class Category
    {
        public string Name { get; set; }  // Name of the product
        public double Price { get; set; } // Price of the product

        // Constructor to initialize the category
        public Category(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Abstract method to be implemented by all derived classes
        public abstract void ShowDetails();
    }

    // BookCategory inheriting from Category
    class BookCategory : Category
    {
        public string Author { get; set; } // Author of the book

        // Constructor to initialize BookCategory item
        public BookCategory(string name, double price, string author) : base(name, price)
        {
            Author = author;
        }

        // Implementation of ShowDetails() for BookCategory
        public override void ShowDetails()
        {
            Console.WriteLine($"[Book] {Name} by {Author} - ${Price}");
        }
    }

    // ClothingCategory inheriting from Category
    class ClothingCategory : Category
    {
        public string ClothType { get; set; } // Type of clothing material

        // Constructor to initialize ClothingCategory item
        public ClothingCategory(string name, double price, string clothType) : base(name, price)
        {
            ClothType = clothType;
        }

        // Implementation of ShowDetails() for ClothingCategory
        public override void ShowDetails()
        {
            Console.WriteLine($"[Clothing] {Name} - Type: {ClothType} - ${Price}");
        }
    }

    // Generic Product class to store different types of category items
    class Product<T> where T : Category
    {
        public T CategoryItem { get; set; }

        public Product(T categoryItem)
        {
            CategoryItem = categoryItem;
        }

        // Show product details
        public void ShowDetails()
        {
            CategoryItem.ShowDetails();
        }
    }

    // Static class to handle discounts
    static class DiscountManager
    {
        public static void ApplyDiscount<T>(Product<T> product, double percentage) where T : Category
        {
            if (percentage < 0 || percentage > 100)
            {
                Console.WriteLine("Invalid discount percentage.");
                return;
            }

            product.CategoryItem.Price -= product.CategoryItem.Price * (percentage / 100);
            Console.WriteLine($"Discount applied: {product.CategoryItem.Name} - New Price: ${product.CategoryItem.Price}");
        }
    }

    // Main program class
    class Program1
    {
        static void Main()
        {
            // Creating book and clothing products
            var book = new Product<BookCategory>(new BookCategory("C# in Depth", 500, "Jon Skeet"));
            var shirt = new Product<ClothingCategory>(new ClothingCategory("T-Shirt", 200, "Linen"));

            Console.WriteLine("Before Discount:");
            book.ShowDetails();
            shirt.ShowDetails();

            // Applying discounts
            DiscountManager.ApplyDiscount(book, 10);
            DiscountManager.ApplyDiscount(shirt, 20);

            Console.WriteLine("\nAfter Discount:");
            book.ShowDetails();
            shirt.ShowDetails();
        }
    }
}