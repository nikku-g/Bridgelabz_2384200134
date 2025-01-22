using System;

class Ninth {
	public static void Main(string[] args) {

		double fee = Convert.ToDouble(Console.ReadLine());
		double discountPercent = Convert.ToDouble(Console.ReadLine());
		double discount = (discountPercent / 100) * fee;
		double finalFee = fee - discount;
		
		Console.WriteLine("The discount amount is INR {0} and final discounted fee is INR {1}", discount, finalFee);
	}
}