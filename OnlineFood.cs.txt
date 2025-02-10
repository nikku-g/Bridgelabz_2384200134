using System;

// Interface for discount functionality
interface IDiscountable 
{
    double ApplyDiscount(double discountPercentage);
    void GetDiscountDetails();
}

// Abstract class representing a food item
abstract class FoodItem {
    protected string ItemName;
    protected double Price;
    protected int Quantity;

    public FoodItem(string itemName, double price, int quantity) {
        ItemName = itemName;
        Price = price;
        Quantity = quantity;
    }

    public abstract double CalculateTotalPrice();

    public void GetItemDetails() {
        Console.WriteLine($"Item: {ItemName}, Price: {Price}, Quantity: {Quantity}");
    }
}

// Veg item class extending FoodItem and implementing IDiscountable
class VegItem : FoodItem, IDiscountable 
{
    public VegItem(string itemName, double price, int quantity) : base(itemName, price, quantity) {}

    public override double CalculateTotalPrice() 
	{
        return Price * Quantity; // No extra charge for veg items
    }

    public double ApplyDiscount(double discountPercentage) 
	{
        return CalculateTotalPrice() * (1 - discountPercentage / 100);
    }

    public void GetDiscountDetails() 
	{
        Console.WriteLine("Veg items get a flat discount based on percentage.");
    }
}

// Non-Veg item class extending FoodItem and implementing IDiscountable
class NonVegItem : FoodItem, IDiscountable 
{
    private const double ADDITIONAL_CHARGE = 20.0;

    public NonVegItem(string itemName, double price, int quantity) : base(itemName, price, quantity) {}

    public override double CalculateTotalPrice()
	{
        return (Price * Quantity) + ADDITIONAL_CHARGE; // Additional charge for non-veg items
    }

    public double ApplyDiscount(double discountPercentage) 
	{
        return CalculateTotalPrice() * (1 - discountPercentage / 100);
    }

    public void GetDiscountDetails() 
	{
        Console.WriteLine("Non-Veg items include an additional charge but are eligible for discounts.");
    }
}

// Main class to demonstrate functionality
class OnlineFoodDeliverySystem 
{
    static void Main(string[] args) 
	{
        FoodItem vegBurger = new VegItem("Veg Burger", 100, 2);
        FoodItem chickenBurger = new NonVegItem("Chicken Burger", 150, 2);
        
        vegBurger.GetItemDetails();
        Console.WriteLine("Total Price: " + vegBurger.CalculateTotalPrice());
        
        chickenBurger.GetItemDetails();
        Console.WriteLine("Total Price: " + chickenBurger.CalculateTotalPrice());
        
        IDiscountable discountedVeg = (IDiscountable)vegBurger;
        Console.WriteLine("Price after discount: " + discountedVeg.ApplyDiscount(10));
        discountedVeg.GetDiscountDetails();
        
        IDiscountable discountedNonVeg = (IDiscountable)chickenBurger;
        Console.WriteLine("Price after discount: " + discountedNonVeg.ApplyDiscount(10));
        discountedNonVeg.GetDiscountDetails();
    }
}