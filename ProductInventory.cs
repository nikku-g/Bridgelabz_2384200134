
using System;

class ProductInventory {

	// Instance Variables
	private string productName;
	private double price;
	// Class Variable
	private static int totalProducts = 0;
	
	public ProductInventory(string productName, double price) {
		this.productName = productName;
		this.price = price;
		totalProducts++;
	}
	
	// Instance Method
	public void DisplayProductDetails() {
		Console.WriteLine("Name: {0}, Price: Rs.{1}", productName, price);
	}
	
	// Class Method
	public static void DisplayTotalProducts() {
		Console.WriteLine("Total Products: {0}", totalProducts);
	}
	
	public static void Main() {
		ProductInventory product1 = new ProductInventory("Laptop", 150000);
		ProductInventory product2 = new ProductInventory("Smartphone", 25000);
		
		// Display Individual Product Details
		product1.DisplayProductDetails();
		product2.DisplayProductDetails();
		
		// Display the no. of Products
		ProductInventory.DisplayTotalProducts();
	}
}

