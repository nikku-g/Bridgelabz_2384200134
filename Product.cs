using System;
using System.Collections.Generic;

// Define the Product class
class Product
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        ProductName = name;
        Price = price;
    }

    // Method to display product details
    public void DisplayProduct()
    {
        Console.WriteLine($"Product: {ProductName}, Price: ${Price}");
    }
}

// Define the Order class
class Order
{
    public string OrderId { get; set; }
    public List<Product> Products { get; set; }
    public decimal TotalAmount { get; private set; }

    public Order(string orderId)
    {
        OrderId = orderId;
        Products = new List<Product>();
        TotalAmount = 0;
    }

    // Add product to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
        TotalAmount += product.Price;
        Console.WriteLine($"Product {product.ProductName} added to Order {OrderId}");
    }

    // Display the order details
    public void DisplayOrder()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine("Products in this order:");
        foreach (var product in Products)
        {
            product.DisplayProduct();
        }
        Console.WriteLine($"Total Amount: ${TotalAmount}");
    }
}

// Define the Customer class
class Customer
{
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }

    public Customer(string name, string email)
    {
        CustomerName = name;
        Email = email;
        Orders = new List<Order>();
    }

    // Place an order
    public void PlaceOrder(Order order)
    {
        Orders.Add(order);
        Console.WriteLine($"{CustomerName} placed an order with Order ID: {order.OrderId}");
    }

    // Display the customer details and their orders
    public void DisplayCustomerOrders()
    {
        Console.WriteLine($"Customer: {CustomerName}, Email: {Email}");
        if (Orders.Count > 0)
        {
            foreach (var order in Orders)
            {
                order.DisplayOrder();
                Console.WriteLine("------------------------------");
            }
        }
        else
        {
            Console.WriteLine("No orders placed yet.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create products
        Product product1 = new Product("Laptop", 40000.00);
        Product product2 = new Product("Smartphone", 12000.00);
        Product product3 = new Product("Headphones", 1000.00);

        // Create a customer
        Customer customer1 = new Customer("Vaibhav", "vaibhavdeol_leone@gmail.com");

        // Create an order for the customer
        Order order1 = new Order("ORD123");
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Customer places the order
        customer1.PlaceOrder(order1);

        // Create another order for the customer
        Order order2 = new Order("ORD124");
        order2.AddProduct(product3);

        // Customer places the second order
        customer1.PlaceOrder(order2);

        // Display the customer's orders and details
        customer1.DisplayCustomerOrders();
    }
}
