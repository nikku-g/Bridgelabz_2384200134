using System;
using System.Collections.Generic;

// Interface for tax-related operations
public interface ITaxable
{
    double CalculateTax();  // Method to calculate tax
    double GetTaxDetails(); // Method to get tax details
}

// Abstract class representing a Product
public abstract class Product
{
    protected string productId;
    protected string name;
    protected double price;

    // Constructor to initialize product details
    public Product(string productId, string name, double price)
    {
        this.productId = productId;
        this.name = name;
        this.price = price;
    }

    // Getter methods for product properties
    public string GetProductId() => productId;
    public string GetName() => name;
    public double GetPrice() => price;

    // Setter method for price with validation
    public void SetPrice(double price)
    {
        if (price < 0)
            Console.WriteLine("Price cannot be negative.");
        else
            this.price = price;
    }

    // Abstract method to be implemented by derived classes
    public abstract double CalculateDiscount();

    // Virtual method to display product details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Product Id: {productId}\nName: {name}\nPrice: {price}");
    }
}

// Electronics class inheriting from Product and implementing ITaxable
public class Electronics : Product, ITaxable
{
    public double discount;
    public double tax;

    // Constructor to initialize electronic product details
    public Electronics(string productId, string name, double price, double discount, double tax)
        : base(productId, name, price)
    {
        this.discount = discount;
        this.tax = tax;
    }

    // Override method to calculate discount
    public override double CalculateDiscount()
    {
        return (price * discount) / 100;
    }

    // Implementing tax calculation
    public double CalculateTax()
    {
        return price + tax - discount;
    }

    // Overridden method to display product details including tax and discount
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Discount: {discount}\nCalculated Discount: {CalculateDiscount()}\nTax: {tax}\nCalculated Tax: {CalculateTax()}\n");
    }

    // Get tax details
    public double GetTaxDetails()
    {
        return tax;
    }
}

// Clothing class inheriting from Product and implementing ITaxable
public class Clothing : Product, ITaxable
{
    public double discount;
    public double tax;

    // Constructor to initialize clothing product details
    public Clothing(string productId, string name, double price, double discount, double tax)
        : base(productId, name, price)
    {
        this.discount = discount;
        this.tax = tax;
    }

    // Override method to calculate discount
    public override double CalculateDiscount()
    {
        return (price * discount) / 100;
    }

    // Implementing tax calculation
    public double CalculateTax()
    {
        return price + tax - discount;
    }

    // Overridden method to display product details including tax and discount
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Discount: {discount}\nCalculated Discount: {CalculateDiscount()}\nTax: {tax}\nCalculated Tax: {CalculateTax()}\n");
    }

    // Get tax details
    public double GetTaxDetails()
    {
        return tax;
    }
}

// Groceries class inheriting from Product and implementing ITaxable
public class Groceries : Product, ITaxable
{
    public double discount;
    public double tax;

    // Constructor to initialize grocery product details
    public Groceries(string productId, string name, double price, double discount, double tax)
        : base(productId, name, price)
    {
        this.discount = discount;
        this.tax = tax;
    }

    // Override method to calculate discount
    public override double CalculateDiscount()
    {
        return (price * discount) / 100;
    }

    // Implementing tax calculation
    public double CalculateTax()
    {
        return price + tax - discount;
    }

    // Overridden method to display product details including tax and discount
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Discount: {discount}\nCalculated Discount: {CalculateDiscount()}\nTax: {tax}\nCalculated Tax: {CalculateTax()}\n");
    }

    // Get tax details
    public double GetTaxDetails()
    {
        return tax;
    }
}

// Main program class
internal class Program1
{
    public static void Main(string[] args)
    {
        // List to store different products
        List<Product> productList = new List<Product>
        {
            new Electronics("Product01", "Laptop", 50000, 10, 5.8),
            new Clothing("Product02", "Top", 2000, 5, 2.0),
            new Groceries("Product03", "Mascara", 3000, 15, 9.2),
        };

        // Display details of each product
        foreach (var item in productList)
        {
            item.DisplayDetails();
        }
    }
}