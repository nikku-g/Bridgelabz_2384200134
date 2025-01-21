using System;

class Fifth {
	public static void Main(string[] args) {
		
		Console.Write("Enter the kilometers: ");
		double km = Convert.ToDouble(Console.ReadLine());
		double mile = km * 0.621371;
		
		Console.WriteLine(mile);
	}
}