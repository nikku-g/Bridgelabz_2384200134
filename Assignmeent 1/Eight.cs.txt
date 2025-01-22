using System;

class Eight {
	public static void Main(string[] args) {
		double km = Convert.ToDouble(Console.ReadLine());
		
		// Converting to miles
		double miles = km * 0.621371;
		Console.WriteLine("The total miles is {0} mile for the given {1} km.", miles, km);

	}
}