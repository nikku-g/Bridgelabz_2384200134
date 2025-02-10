using System;

// Interface for GPS functionality
interface IGPS {
    string GetCurrentLocation();
    void UpdateLocation(string newLocation);
}

// Abstract class representing a vehicle
abstract class Vehicle 
{
    private int VehicleId;
    private string DriverName;
    protected double RatePerKm;

    public Vehicle(int vehicleId, string driverName, double ratePerKm) {
        VehicleId = vehicleId;
        DriverName = driverName;
        RatePerKm = ratePerKm;
    }

    public abstract double CalculateFare(double distance);

    public void GetVehicleDetails() {
        Console.WriteLine($"Vehicle ID: {VehicleId}, Driver: {DriverName}, Rate per Km: {RatePerKm}");
    }
}

// Car class extending Vehicle and implementing IGPS
class Car : Vehicle, IGPS {
    private string Location;

    public Car(int vehicleId, string driverName, double ratePerKm) : base(vehicleId, driverName, ratePerKm) {}

    public override double CalculateFare(double distance) {
        return RatePerKm * distance;
    }

    public string GetCurrentLocation() {
        return Location;
    }

    public void UpdateLocation(string newLocation) {
        Location = newLocation;
    }
}

// Bike class extending Vehicle and implementing IGPS
class Bike : Vehicle, IGPS 
{
    private string Location;

    public Bike(int vehicleId, string driverName, double ratePerKm) : base(vehicleId, driverName, ratePerKm) {}

    public override double CalculateFare(double distance)
	{
        return RatePerKm * distance * 0.8; // Discounted fare for bikes
    }

    public string GetCurrentLocation() 
	{
        return Location;
    }

    public void UpdateLocation(string newLocation)
	{
        Location = newLocation;
    }
}

// Auto class extending Vehicle and implementing IGPS
class Auto : Vehicle, IGPS 
{
    private string Location;

    public Auto(int vehicleId, string driverName, double ratePerKm) : base(vehicleId, driverName, ratePerKm) {}

    public override double CalculateFare(double distance) 
	{
        return RatePerKm * distance * 0.9; // Slightly discounted fare for autos
    }

    public string GetCurrentLocation()
	{
        return Location;
    }

    public void UpdateLocation(string newLocation)
	{
        Location = newLocation;
    }
}

// Main class to demonstrate functionality
class RideHailingApp 
{
    static void ProcessRide(Vehicle vehicle, double distance) 
	{
        vehicle.GetVehicleDetails();
        Console.WriteLine("Total Fare: " + vehicle.CalculateFare(distance));
    }

    static void Main(string[] args)
	{
        Vehicle car = new Car(101, "Vanshita", 10);
        Vehicle bike = new Bike(102, "Simran", 8);
        Vehicle auto = new Auto(103, "Misti", 9);
        
        ProcessRide(car, 15);
        ProcessRide(bike, 15);
        ProcessRide(auto, 15);
    }
}