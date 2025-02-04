
using System;

class HotelBooking {
	private string guestName {get; set;}
	private string roomType {get; set;}
	private int nights {get; set;}
	
	// Default Constructor //
	public HotelBooking() {
		guestName = "Ramesh D'souza";
		roomType = "Full AC";
		nights = 4;
	}
	
	// Parameterized Constructor //
	public HotelBooking(string guest, string room, int nights) {
		this.guestName = guest;
		this.roomType = room;
		this.nights = nights;
	}
	
	// Copy Constructor //
	public HotelBooking(HotelBooking hotels) {
		this.guestName = hotels.guestName;
		this.roomType = hotels.roomType;
		this.nights = hotels.nights;
	}
	
	public void display() {
		Console.WriteLine("Name: {0}, Room: {1}, Nights: {2}", guestName, roomType, nights);
	}
	
	public static void Main(string[] args) {
		// Using default constructor //
		HotelBooking defaultBooking = new HotelBooking();
		Console.WriteLine("Default Data: ");
		defaultBooking.display();
		
		// Using parameterized constructor //
		HotelBooking customBooking = new HotelBooking("Naresh", "Standard", 3);
		Console.WriteLine("Custom Data: ");
		customBooking.display();
		
		// Using copy constructor //
		HotelBooking copiedBooking = new HotelBooking(customBooking);
		Console.WriteLine("Copied Data: ");
		copiedBooking.display();
	}
}

