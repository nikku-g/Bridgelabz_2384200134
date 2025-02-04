
using System;

class Vehicle {
	
	// Instance Variables
	private string ownerName;
	private string vehicleType;
	// Class Variables
	private static double registrationFee = 2500;
	
	public Vehicle(string ownerName, string vehicleType) {
		this.ownerName = ownerName;
		this.vehicleType = vehicleType;
	}
	
	// Instance Methods
	public void DisplayVehicleDetails() {
		Console.WriteLine("Name: {0}, Type: {1}, Registration Fees: {2}", ownerName, vehicleType, registrationFee);
	}
	
	// Class Methods
	public static void UpdateRegistrationFee(double newFee) {
		registrationFee = newFee;
	}
}
class Program {
	public static void Main() {
		Vehicle vehicle = new Vehicle("Ramesh", "Four Wheeler");
		
		// Display details with default fees
		Console.WriteLine("Vehicle Details: ");
		vehicle.DisplayVehicleDetails();
		
		Vehicle.UpdateRegistrationFee(3000);
		
		// Display details with updated fees
		Console.WriteLine("Updated Details: ");
		vehicle.DisplayVehicleDetails();
	}
}

