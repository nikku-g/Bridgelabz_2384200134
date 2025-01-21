using System;

class Second {
	public static void Main(string[] args) {
		
		Console.Write("Enter the first number: ");
		int num1 = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the second number: ");
		int num2 = Convert.ToInt32(Console.ReadLine());
		
		int sum = num1 + num2;
		
		Console.WriteLine(sum);
	}
}