using System;

class Twelfth {
	public double area(double b, double h) {
		return (b*h)/2;
	}
	
	public static void Main(string[] args) {
		double bas = Convert.ToDouble(Console.ReadLine());
		double height = Convert.ToDouble(Console.ReadLine());
		
		Twelfth tw = new Twelfth();
		double result = tw.area(bas, height);
		double cmToInches = result / 6.4516;
		
		Console.WriteLine("Area of triangle in cm2 is {0} and in inches2 is {1}", result, cmToInches);
	}
}

