using System;

class Third {
	public static void Main(string[] args) {
		
		int base = Convert.ToInt32(Console.ReadLine());
		int expo = Convert.ToInt32(Console.ReadLine());
		
		int power = Math.Pow(base, expo);
		Console.WriteLine(power);
	}
}