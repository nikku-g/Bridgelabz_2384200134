using System;

class Seventh {
	public static void Main(string[] args) {
		double radiusOfEarth = 6378;
		double kmToMile = 0.621371;
		
		double volumeOfEarthKm3 = (4.0 / 3.0) * Math.PI * Math.Pow(radiusOfEarth, 3);
		
		// Converting km to miles
		double radiusOfEarthmiles = radiusOfEarth * kmToMile;
		
		double volumeOfEarthmile3 = (4.0 / 3.0) * Math.PI * Math.Pow(radiusOfEarthmiles, 3);
		Console.WriteLine("The volume of earth in cubic kilometers is {0} and cubic miles is {1}", volumeOfEarthKm3, volumeOfEarthmile3);
	}
}