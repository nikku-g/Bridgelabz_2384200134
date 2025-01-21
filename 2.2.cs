using System;

class Second {
	public static void Main(string[] args) {
		
		Console.Write("Enter the length of rectangle: ");
		double length = Convert.ToDouble(Console.ReadLine());
		
		Console.Write("Enter the width of rectangle: ");
		double width = Convert.ToDouble(Console.ReadLine());
		
		double perimeter = 2 * (length+width);
		
		Console.WriteLine(perimeter);
	}
}