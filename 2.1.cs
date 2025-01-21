using System;

class First {
	public static void Main(string[] args) {
		
		Console.Write("Enter the principal: ");
		long principal = Convert.ToInt64(Console.ReadLine());
		
		Console.Write("Enter the rate of interest: ");
		int rate = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the time: ");
		int time = Convert.ToInt32(Console.ReadLine());
		
		double SI = (principal*rate*time)/100;
		
		Console.WriteLine(SI);
	}
}