using System;

public class MaxNumberOfHandshakes
{
	// Creating a method Handshakes to find maximum number of handshakes
	public void Handshakes()
	{
		// Taking user input to enter the number of students
        Console.Write("Enter the number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Calculate the maximum number of handshakes using the formula (N * (N - 1)) / 2
        int maxHandshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        // Displaying the result
        Console.WriteLine("The maximum number of handshakes among {0} students is {1}", numberOfStudents, maxHandshakes);
    }
	
	public static void Main(String[] args)
	{
		// Creating an object of the classname
		MaxNumberOfHandshakes max = new MaxNumberOfHandshakes();
		
		// Calling the method
		max.Handshakes();
    }
}