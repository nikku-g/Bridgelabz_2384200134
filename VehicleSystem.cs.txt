using System;

// Base class: Vehicle
class Vehicle
{
    public int MaxSpeed { get; set; }
    public string FuelType { get; set; }

    public Vehicle(int maxSpeed, string fuelType)
    {
        MaxSpeed = maxSpeed;
        FuelType = fuelType;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Max Speed: {0} km/h, Fuel Type: {1}", MaxSpeed, FuelType);
    }
}

// Subclass: Car
class Car : Vehicle
{
    public int SeatCapacity { get; set; }

    public Car(int maxSpeed, string fuelType, int seatCapacity) : base(maxSpeed, fuelType)
    {
        SeatCapacity = seatCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Seat Capacity: {0}", SeatCapacity);
    }
}

// Subclass: Truck
class Truck : Vehicle
{
    public int PayloadCapacity { get; set; }

    public Truck(int maxSpeed, string fuelType, int payloadCapacity) : base(maxSpeed, fuelType)
    {
        PayloadCapacity = payloadCapacity;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Payload Capacity: {0} kg", PayloadCapacity);
    }
}

// Subclass: Motorcycle
class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motorcycle(int maxSpeed, string fuelType, bool hasSidecar) : base(maxSpeed, fuelType)
    {
        HasSidecar = hasSidecar;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Has Sidecar: {0}", HasSidecar);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car(220, "Petrol", 5),
            new Truck(120, "Diesel", 5000),
            new Motorcycle(180, "Petrol", false)
        };
        
        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayInfo();
            Console.WriteLine();
        }
    }
}
