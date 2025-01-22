using System;

class Fourteenth {
	public double convertToYard(double feet) {
		return feet/3;
	}
	public double convertToMile(double feet) {
		return feet/5280;
	}
		
	public static void Main(string[] args) {
		double distanceInFeet = Convert.ToDouble(Console.ReadLine());
		
		Fourteenth ft = new Fourteenth();
		double distanceInYards = ft.convertToYard(distanceInFeet);
		double distanceInMiles = ft.convertToMile(distanceInFeet);
		
		Console.WriteLine("Distance in feet is {0} and distance in yards is {1} and distance in miles is {2}", distanceInFeet, distanceInYards, distanceInMiles);
	}
}