using System;

class Eleventh {
	public double addition(double a, double b) {
		return a+b;
	}
	public double subtraction(double a, double b) {
		return a-b;
	}
	public double multiplication(double a, double b) {
		return a*b;
	}
	public double division(double a, double b) {
		return a/b;
	}
	
	public static void Main(string[] args) {
		double num1 = Convert.ToDouble(Console.ReadLine());
		double num2 = Convert.ToDouble(Console.ReadLine());
		
		Eleventh ev = new Eleventh();
		double add = ev.addition(num1, num2);
		double sub = ev.subtraction(num1, num2);
		double mul = ev.multiplication(num1, num2);
		double div = ev.division(num1, num2);
		
		Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers {0} and {1} is {2}, {3}, {4} and {5}", num1, num2, add, sub, mul, div);
		
	}
}