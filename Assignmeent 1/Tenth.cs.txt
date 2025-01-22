using System;

class Tenth {
	public static void Main(string[] args) {
		double height = Convert.ToDouble(Console.ReadLine());
		
		double cmToInches = 2.54;
		double inchesToFeet = 12;
		
		double totalInches = height / cmToInches;
		double heightInFeet = totalInches / inchesToFeet;
		
		double remainingInches = totalInches % inchesToFeet;
		Console.WriteLine("Your Height in cm is {0} while in feet is {1} and inches is {2}", height, heightInFeet, remainingInches);
	}
}