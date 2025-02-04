using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartSystem
{
    internal class ShopingCart
    {
        private static double Discount = 20;
        private string ProductName;
        private readonly string ProductID;
        private double Price;
        private int Quantity;

        public ShopingCart(string ProductName, int Quantity, double Price)
        {
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public static void UpdateDiscount(double discount)
        {
            Discount = discount;
            Console.WriteLine($"current discount for all product is {Discount}");
            Console.WriteLine();
        }
        public void DisplayProductDetails()
        {
            double discountedPrice = Price - (Price * Discount / 100);
            Console.WriteLine($"Product ID: {ProductID}");
            Console.WriteLine($"Product Name: {ProductName}");
            Console.WriteLine($"Price: rs{Price}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Discount: {Discount}%");
            Console.WriteLine($"Discounted Price: rs{discountedPrice}");
        }
        public static void CheckIfProduct(object obj)
        {
            if (obj is ShopingCart)
            {
                ShopingCart product = (ShopingCart)obj;
                product.DisplayProductDetails();
            }
            else
            {
                Console.WriteLine("This is not a valid Product object.");
            }
        }


        private List<ShopingCart> products;

        public ShopingCart()
        {
            products = new List<ShopingCart>();
        }

        // Method to add product to the shopping cart
        public void AddProduct(ShopingCart product)
        {
            if (product is ShopingCart)
            {
                products.Add(product);
                Console.WriteLine($"Added {product.ProductName} to the cart.");
            }
            else
            {
                Console.WriteLine("Only valid Product objects can be added to the cart.");
            }
        }

        public void DisplayCartDetails()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Your shopping cart is empty.");
                return;
            }

            Console.WriteLine("Your Shopping Cart:");
            foreach (var product in products)
            {
                product.DisplayProductDetails();
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                // Create products
                ShopingCart product1 = new ShopingCart("Laptop", 2, 49500);
                ShopingCart product2 = new ShopingCart("Smartphone", 2, 15499.5);
                while (true)
                {
                    Console.WriteLine("Choose the number to perform operation");
                    Console.WriteLine("1. Check all Products");
                    Console.WriteLine("2. Update discount");
                    Console.WriteLine("3. updated discount product detail");
                    Console.WriteLine("4. Add product 1 in cart");
                    Console.WriteLine("5. Add product 2 in cart");
                    Console.WriteLine("6. Exit");

                    int Choice = Convert.ToInt32(Console.ReadLine());
                    ShopingCart cart = new ShopingCart();
                    switch (Choice)
                    {
                        case 1:
                            product1.DisplayProductDetails();
                            product2.DisplayProductDetails();
                            break;

                        case 2:// Display product details before discount update
                            ShopingCart.UpdateDiscount(15.0);
                            break;

                        case 3:// Update discount for all products
                            product1.DisplayProductDetails();
                            product2.DisplayProductDetails();
                            break;

                        case 4: // Create a shopping cart and add products
                            cart.AddProduct(product1);
                            cart.DisplayCartDetails();
                            break;

                        case 5:// Create a shopping cart and add products
                            cart.AddProduct(product2);
                            cart.DisplayCartDetails();
                            break;
                    }
                    if (Choice == 6)
                    {
                        break;
                    }
                }
                    // Check if an object is a valid Product
                    ShopingCart.CheckIfProduct(product1);
                ShopingCart.CheckIfProduct("Not a Product");
            }
        }
        
    }
}
