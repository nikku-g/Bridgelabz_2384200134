using System;

class Program1
{
    // Method to calculate how many pens each student will get
    public int CalculatePensPerStudent(int totalPens, int totalStudents)
    {
        return totalPens / totalStudents;  // Using division operator to get pens per student
    }

    // Method to calculate the remaining pens
    public static int CalculateRemainingPens(int totalPens, int totalStudents)
    {
        return totalPens % totalStudents;  // Using modulus operator to get remaining pens
    }

    static void Main()
    {
        // Given values
        int totalPens = 14;
        int totalStudents = 3;

        // Calling methods to calculate the pens per student and remaining pens
        Program1 p = new Program1(); // Create an instance of Program1 to call the non-static method
        int pensPerStudent = p.CalculatePensPerStudent(totalPens, totalStudents); // Corrected to use 'p' instead of 'P'
        int remainingPens = CalculateRemainingPens(totalPens, totalStudents); // Static method call does not need an instance

        // Printing the result
        Console.WriteLine("The Pen Per Student is {0} and the remaining pen not distributed is {1}", pensPerStudent, remainingPens);
    }
}
