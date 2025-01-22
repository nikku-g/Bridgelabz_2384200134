using System;

class Fifteenth {
	public static void Main(string[] args) {
		double unitPrice = Convert.ToDouble(Console.ReadLine());
		int quantity = Convert.ToInt32(Console.ReadLine());
		
		double totalPrice = (double)(unitPrice * quantity);
		Console.WriteLine("The total purchase price is INR {0} if the quantity {1} and unit price is INR {2}", totalPrice, quantity, unitPrice);
	}
}