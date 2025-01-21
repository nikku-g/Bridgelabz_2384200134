using System;

class Fourth {
	public static void Main(string[] args) {
		
		int num1 = Convert.ToInt32(Console.ReadLine());
		int num2 = Convert.ToInt32(Console.ReadLine());
		int num3 = Convert.ToInt32(Console.ReadLine());
		
		int avg = (num1+num2+num3)/3;
		
		Console.WriteLine(avg);
	}
}