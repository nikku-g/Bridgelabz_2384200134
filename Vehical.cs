using System;

class Vehicle
{
    // Static variable shared among all vehicles
    public static double RegistrationFee = 100.00;

    // Readonly variable to uniquely identify each vehicle
    public readonly string RegistrationNumber;

    // Instance variables for OwnerName and VehicleType
    public string OwnerName { get; set; }
    public string VehicleType { get; set; }

    // Constructor to initialize vehicle details
    public Vehicle(string ownerName, string vehicleType, string registrationNumber)
    {
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
        this.RegistrationNumber = registrationNumber;
    }

    // Static method to update the registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
        Console.WriteLine($"Registration fee updated to: {RegistrationFee:C}");
    }

    // Method to display vehicle registration details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Vehicle Type: {VehicleType}");
        Console.WriteLine($"Registration Number: {RegistrationNumber}");
        Console.WriteLine($"Registration Fee: {RegistrationFee:C}");
    }
}

class Vehical
{
    // Define the maximum number of vehicles that can be handled
    static int maxVehicles = 100;
    static Vehicle[] vehicles = new Vehicle[maxVehicles];
    static int currentVehicleCount = 0;

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Vehicle Registration System");
            Console.WriteLine("1. Register New Vehicle");
            Console.WriteLine("2. Update Vehicle Details");
            Console.WriteLine("3. Delete Vehicle");
            Console.WriteLine("4. Validate Vehicle Registration Number");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    RegisterNewVehicle();
                    break;
                case 2:
                    UpdateVehicleDetails();
                    break;
                case 3:
                    DeleteVehicle();
                    break;
                case 4:
                    ValidateRegistrationNumber();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void RegisterNewVehicle()
    {
        if (currentVehicleCount >= maxVehicles)
        {
            Console.WriteLine("\nCannot register more vehicles. System is at full capacity.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nEnter Vehicle Details:");
        Console.Write("Owner Name: ");
        string ownerName = Console.ReadLine();
        Console.Write("Vehicle Type: ");
        string vehicleType = Console.ReadLine();
        Console.Write("Registration Number: ");
        string registrationNumber = Console.ReadLine();

        // Check if registration number already exists
        foreach (var vehicle in vehicles)
        {
            if (vehicle != null && vehicle.RegistrationNumber == registrationNumber)
            {
                Console.WriteLine("\nError: Registration number already exists.");
                Console.ReadKey();
                return;
            }
        }

        // Create a new Vehicle and add it to the array
        vehicles[currentVehicleCount] = new Vehicle(ownerName, vehicleType, registrationNumber);
        currentVehicleCount++;

        Console.WriteLine("\nVehicle registered successfully!");
        Console.WriteLine($"Registration Number: {registrationNumber}");
        Console.ReadKey();
    }

    static void UpdateVehicleDetails()
    {
        Console.WriteLine("\nEnter Vehicle Registration Number to Update:");
        string regNumber = Console.ReadLine();

        Vehicle vehicleToUpdate = null;
        for (int i = 0; i < currentVehicleCount; i++)
        {
            if (vehicles[i].RegistrationNumber == regNumber)
            {
                vehicleToUpdate = vehicles[i];
                break;
            }
        }

        if (vehicleToUpdate != null)
        {
            Console.WriteLine($"\nUpdating details for Vehicle with Registration Number: {regNumber}");
            Console.Write("New Owner Name (Leave empty to keep unchanged): ");
            string newOwnerName = Console.ReadLine();
            Console.Write("New Vehicle Type (Leave empty to keep unchanged): ");
            string newVehicleType = Console.ReadLine();

            if (!string.IsNullOrEmpty(newOwnerName)) vehicleToUpdate.OwnerName = newOwnerName;
            if (!string.IsNullOrEmpty(newVehicleType)) vehicleToUpdate.VehicleType = newVehicleType;

            Console.WriteLine("\nVehicle details updated successfully!");
        }
        else
        {
            Console.WriteLine("Vehicle not found with the given registration number.");
        }
        Console.ReadKey();
    }

    static void DeleteVehicle()
    {
        Console.WriteLine("\nEnter Vehicle Registration Number to Delete:");
        string regNumber = Console.ReadLine();

        int indexToDelete = -1;
        for (int i = 0; i < currentVehicleCount; i++)
        {
            if (vehicles[i].RegistrationNumber == regNumber)
            {
                indexToDelete = i;
                break;
            }
        }

        if (indexToDelete != -1)
        {
            // Shift remaining vehicles
            for (int i = indexToDelete; i < currentVehicleCount - 1; i++)
            {
                vehicles[i] = vehicles[i + 1];
            }

            // Set last element to null
            vehicles[currentVehicleCount - 1] = null;
            currentVehicleCount--;

            Console.WriteLine("\nVehicle deleted successfully!");
        }
        else
        {
            Console.WriteLine("Vehicle not found with the given registration number.");
        }
        Console.ReadKey();
    }

    static void ValidateRegistrationNumber()
    {
        Console.WriteLine("\nEnter Vehicle Registration Number to Validate:");
        string regNumber = Console.ReadLine();

        bool isValid = false;
        foreach (var vehicle in vehicles)
        {
            if (vehicle != null && vehicle.RegistrationNumber == regNumber)
            {
                isValid = true;
                vehicle.DisplayVehicleDetails();
                break;
            }
        }

        if (!isValid)
        {
            Console.WriteLine("Invalid or non-existent registration number.");
        }

        Console.ReadKey();
    }
}