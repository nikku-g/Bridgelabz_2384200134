using System;

public class SimpleInterest
{
	// Creating a method Simple for calculating simple interest
	public void Simple()
	{
		// Taking user input for Principal
        Console.Write("Enter the Principal amount: ");
        double principal = Convert.ToDouble(Console.ReadLine());

        // Taking user input for Rate of Interest
        Console.Write("Enter the Rate of Interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        // Taking user input for Time (in years)
        Console.Write("Enter the Time: ");
        double time = Convert.ToDouble(Console.ReadLine());

        // Calculating Simple Interest 
        double simpleInterest = (principal * rate * time) / 100;

        // Displaying the result
        Console.WriteLine("The Simple Interest is {0} for Principal {1}, Rate of Interest {2}% and Time {3} years.", simpleInterest, principal, rate, time);
    }
	
	public static void Main(String[] args)
	{
		// Creating an object of the classname
		SimpleInterest si = new SimpleInterest();
		
		// Calling the method
		si.Simple();
	}	
}