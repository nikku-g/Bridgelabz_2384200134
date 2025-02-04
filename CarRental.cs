
using System;

class CarRental
{
    private string customerName;
    private string carModel;
    private int rentalDays;
    private const double dailyRate = 50.0;

    // Default constructor
    public CarRental() : this("Unknown", "Standard", 1) 
    {
    }

    // Parameterized constructor
    public CarRental(string customerName, string carModel, int rentalDays)
    {
        this.customerName = customerName;
        this.carModel = carModel;
        this.rentalDays = rentalDays;
    }

    // Method to calculate total rental cost
    public double CalculateTotalCost()
    {
        return rentalDays * dailyRate;
    }

    // Method to display rental details
    public void Display()
    {
        Console.WriteLine("Customer: {0}, Car Model: {1}, Rental Days: {2}", customerName, carModel, rentalDays);
        Console.WriteLine("Total Cost: {0}", CalculateTotalCost());
    }
}

class Program
{
    public static void Main()
    {
        // Using default constructor
        CarRental defaultRental = new CarRental();
        Console.WriteLine("Default Rental:");
        defaultRental.Display();
        
        Console.WriteLine();

        // Using parameterized constructor
        CarRental customRental = new CarRental("Alice Johnson", "SUV", 5);
        Console.WriteLine("Custom Rental:");
        customRental.Display();
    }
}

