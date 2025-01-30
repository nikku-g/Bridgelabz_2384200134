using System;

class BMI
{
    public static void Main()
    {
        // Take input for the number of persons
        Console.Write("Enter the number of persons: ");
		int numberOfPersons = Convert.ToInt32(Console.ReadLine());
		if(numberOfPersons < 1 || numberOfPersons > int.MaxValue) {
			Console.Error.WriteLine("Please enter a valid positive integer.");
			Environment.Exit(0);
		}

        // Define arrays to store height, weight, BMI, and weight status
        double[] heights = new double[numberOfPersons];
        double[] weights = new double[numberOfPersons];
        double[] bmis = new double[numberOfPersons];
        string[] statuses = new string[numberOfPersons];

        // Take input for height and weight of each person
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Enter details for person {0}:", i+1);

            Console.Write("Height (in meters): ");
			heights[i] = Convert.ToDouble(Console.ReadLine());
			if(heights[i] < 0.5 || heights[i] > 3.0) {
				Console.WriteLine("Please enter a valid height in meters.");
				Environment.Exit(0);
			}

            Console.Write("Weight (in kilograms): ");
			weights[i] = Convert.ToDouble(Console.ReadLine());
			if(weights[i] < 10 || weights[i] > 500) {
				Console.WriteLine("Please enter a valid weight in kilograms.");
				Environment.Exit(0);
			}
        }

        // Calculate BMI and determine weight status for each person
        for (int i = 0; i < numberOfPersons; i++)
        {
            bmis[i] = CalculateBMI(heights[i], weights[i]);
            statuses[i] = DetermineWeightStatus(bmis[i]);
        }

        // Display the height, weight, BMI, and weight status of each person
        Console.WriteLine("\nDetails of each person:");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Person {0}: Height = {1} m, Weight = {2} kg, BMI = {3}, Status = {4}", (i+1), heights[i], weights[i], bmis[i], statuses[i]);
        }
    }

    // Method to calculate BMI
    static double CalculateBMI(double height, double weight)
    {
        return weight / (height * height);
    }

    // Method to determine weight status based on BMI
    static string DetermineWeightStatus(double bmi)
    {
        if (bmi <= 18.4)
            return "Underweight";
        else if (bmi > 18.5 && bmi < 24.9)
            return "Normal weight";
        else if (bmi > 25 && bmi < 39.9)
            return "Overweight";
        else
            return "Obese";
    }
}
