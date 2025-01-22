using System;

class Fifth {
	public static void Main(string[] args) {
		int noOfPens = 14;
		int noOfStudents = 3;
		
		int penEachStudentGet = 14 / 3;
		int remainingPens = noOfPens % noOfStudents;
		
		Console.WriteLine("The Pen Per Student is {0} and the remaining pen not distributed is {1}", penEachStudentGet, remainingPens);
	}
}