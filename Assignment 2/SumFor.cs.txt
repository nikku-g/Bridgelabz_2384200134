using System;

public class SumFor
{
    // Creating the Method to handle computation
    public static void ComputeAndCompareSum()
    {
        Console.Write("Enter a positive integer (natural number): ");
        int n = Convert.ToInt32(Console.ReadLine());  // Take user input

        // Check if the entered number is a valid natural number
        if (n <= 0)
        {
            Console.WriteLine("Please enter a positive integer greater than 0.");
            return;  // Exit the method if the number is not valid
        }

        // Sum using for loop
        int sumForLoop = 0;
        for (int i = 1; i <= n; i++)
        {
            sumForLoop += i;  // Add the current number to sum
        }

        // Display the results
        Console.WriteLine("Sum using for loop: {0}", sumForLoop);
	}	

	public static void Main(String[] args)
    {
         // Calling the method to computation
         ComputeAndCompareSum();
    }
}