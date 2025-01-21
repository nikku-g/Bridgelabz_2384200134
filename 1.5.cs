using System;

class Fifth {
	public static void Main(string[] args) {
		
		Console.Write("Enter the radius of cylinder: ");
		double radius = Convert.ToDouble(Console.ReadLine());
		
		Console.Write("Enter the height of cylinder: ");
		double height = Convert.ToDouble(Console.ReadLine());
		
		double volume = Math.PI * Math.Pow(radius, 2) * height;
		
		Console.WriteLine(volume);
	}
}