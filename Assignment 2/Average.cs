using System;

class Average{
	public int AverageMarks(int Maths, int Physics, int Chemistry){
		int AvgPercent = (Maths + Physics + Chemistry)/3;
		return AvgPercent;
	}
	
	static void Main(string[]args){
	int Maths = 94;
	int Physics = 95;
	int Chemistry = 96;
	Average avg = new Average();
	Console.WriteLine("sam's average is: ");
	Console.WriteLine(avg.AverageMarks(Maths, Physics, Chemistry));
	}
}