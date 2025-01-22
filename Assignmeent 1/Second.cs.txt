using System;

class Second {
	public static void Main(string[] args) {
		int samMarksMaths = 94;
		int samMarksPhysics = 95;
		int samMarksChemistry = 96;
		
		int avgMarks = (samMarksMaths + samMarksChemistry + samMarksPhysics) / 3;
		Console.WriteLine("Sam's average mark in PCM is {0}", avgMarks);
	}
}