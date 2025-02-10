using System;
using System.Collections.Generic;

// Interface for insurance-related operations
public interface IInsurable
{
    double CalculateInsurance();  // Method to calculate insurance cost
    string GetInsuranceDetails(); // Method to retrieve insurance details
}

// Abstract class representing a Vehicle
public abstract class Vehicle : IInsurable
{
    protected string vehicleNumber;
    protected string type;
    protected double rentalRate;
    private string insurancePolicyNumber; // Encapsulated insurance policy number

    // Constructor to initialize vehicle details
    public Vehicle(string vehicleNumber, string type, double rentalRate, string insurancePolicyNumber)
    {
        this.vehicleNumber = vehicleNumber;
        this.type = type;
        this.rentalRate = rentalRate;
        this.insurancePolicyNumber = insurancePolicyNumber;
    }

    // Abstract method to be implemented by subclasses
    public abstract double CalculateRentalCost(int days);

    // Implementing insurance calculation
    public virtual double CalculateInsurance()
    {
        return rentalRate * 0.05; // Example: 5% of rental rate
    }

    // Encapsulated method to get insurance details
    public string GetInsuranceDetails()
    {
        return "Insurance details are confidential.";
    }

    // Virtual method to display vehicle details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Vehicle Number: {vehicleNumber}\nType: {type}\nRental Rate: {rentalRate}\nInsurance Cost: {CalculateInsurance()}\n{GetInsuranceDetails()}\n");
    }
}

// Car class inheriting from Vehicle
public class Car : Vehicle
{
    public Car(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
        : base(vehicleNumber, "Car", rentalRate, insurancePolicyNumber) { }

    public override double CalculateRentalCost(int days)
    {
        return days * rentalRate;
    }
}

// Bike class inheriting from Vehicle
public class Bike : Vehicle
{
    public Bike(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
        : base(vehicleNumber, "Bike", rentalRate, insurancePolicyNumber) { }

    public override double CalculateRentalCost(int days)
    {
        return days * rentalRate;
    }
}

// Truck class inheriting from Vehicle
public class Truck : Vehicle
{
    public Truck(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
        : base(vehicleNumber, "Truck", rentalRate, insurancePolicyNumber) { }

    public override double CalculateRentalCost(int days)
    {
        return days * rentalRate; 
    }
}

// Main program class
internal class Program
{
    public static void Main(string[] args)
    {
        // List to store different vehicles
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("CAR123", 50, "INS123"),
            new Bike("BIKE456", 30, "INS456"),
            new Truck("TRUCK789", 100, "INS789"),
        };

        int rentalDays = 5;

        // Display details and calculate rental and insurance costs for each vehicle
        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayDetails();
            Console.WriteLine($"Rental Cost for {rentalDays} days: {vehicle.CalculateRentalCost(rentalDays)}\n");
        }
    }
}