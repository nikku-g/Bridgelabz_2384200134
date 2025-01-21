using System;

class Fourth {
	public static void Main(string[] args) {
		
		Console.Write("Enter the radius of circle: ");
		double radius = Convert.ToDouble(Console.ReadLine());
		
		double area = Math.PI * (Math.Pow(radius, 2));
		
		Console.WriteLine(area);
	}
}