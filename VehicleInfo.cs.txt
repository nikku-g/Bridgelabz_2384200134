using System;

// Base class: Vehicle
class Vehicle
{
    public string Model { get; set; }
    public int MaxSpeed { get; set; }

    public Vehicle(string model, int maxSpeed)
    {
        Model = model;
        MaxSpeed = maxSpeed;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle Model: {Model}, Max Speed: {MaxSpeed} km/h");
    }
}

// Interface: Refuelable
interface Refuelable
{
    void Refuel();
}

// Subclass: ElectricVehicle
class ElectricVehicle : Vehicle
{
    public int BatteryCapacity { get; set; } // in kWh

    public ElectricVehicle(string model, int maxSpeed, int batteryCapacity) : base(model, maxSpeed)
    {
        BatteryCapacity = batteryCapacity;
    }

    public void Charge()
    {
        Console.WriteLine($"Electric Vehicle {Model} is charging with {BatteryCapacity} kWh battery capacity.");
    }
}

// Subclass: PetrolVehicle
class PetrolVehicle : Vehicle, Refuelable
{
    public int FuelTankCapacity { get; set; } // in liters

    public PetrolVehicle(string model, int maxSpeed, int fuelTankCapacity) : base(model, maxSpeed)
    {
        FuelTankCapacity = fuelTankCapacity;
    }

    public void Refuel()
    {
        Console.WriteLine($"Petrol Vehicle {Model} is refueling with {FuelTankCapacity} liters of fuel.");
    }
}

// Main program
class Program
{
    static void Main()
    {
        ElectricVehicle ev = new ElectricVehicle("Tesla Model 3", 200, 75);
        PetrolVehicle pv = new PetrolVehicle("Ford Mustang", 250, 60);
        
        ev.DisplayInfo();
        ev.Charge();
        Console.WriteLine();
        
        pv.DisplayInfo();
        pv.Refuel();
    }
}
