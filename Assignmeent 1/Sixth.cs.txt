using System;

class Sixth {
	public static void Main(string[] args) {
		double fee = 125000;
		double discountPercent = 10;
		double discount = (discountPercent / 100) * fee;
		double finalFee = fee - discount;
		
		Console.WriteLine("The discount amount is INR {0} and final discounted fee is INR {1}", discount, finalFee);
	}
}