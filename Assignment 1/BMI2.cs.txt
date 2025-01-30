using System;

class BMI2
{
    public static void Main(string[] args)
    {
        // Take input for the number of persons
        Console.Write("Enter the number of persons: ");
		int numberOfPersons = Convert.ToInt32(Console.ReadLine());
		if(numberOfPersons < 1 || numberOfPersons > int.MaxValue) {
			Console.Error.WriteLine("Please enter a valid positive integer.");
			Environment.Exit(0);
		}

        // Define a 2D array to store height, weight, and BMI
        double[][] personData = new double[numberOfPersons][];
        for (int i = 0; i < numberOfPersons; i++)
        {
            personData[i] = new double[3]; // Each row will store [height, weight, BMI]
        }

        // Define an array to store the weight status
        string[] weightStatus = new string[numberOfPersons];

        // Take input for height and weight of each person
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Enter details for person {0}:", i+1);

            Console.Write("Height (in centimeters): ");
			personData[i][0] = Convert.ToDouble(Console.ReadLine());
			if(personData[i][0] < 0.5 || personData[i][0] > 3.0) {
				Console.Error.WriteLine("Please enter a valid height in meters.");
				Environment.Exit(0);
			}

            Console.Write("Weight (in kilograms): ");
			personData[i][1] = Convert.ToDouble(Console.ReadLine());
			if(personData[i][1] < 10 || personData[i][1] > 500) {
				Console.Error.WriteLine("Please enter a valid weight in kilograms.");
				Environment.Exit(0);
			}
        }

        // Calculate BMI and determine weight status for each person
        for (int i = 0; i < numberOfPersons; i++)
        {
            personData[i][2] = CalculateBMI(personData[i][0], personData[i][1]);
            weightStatus[i] = DetermineWeightStatus(personData[i][2]);
        }

        // Display the height, weight, BMI, and weight status of each person
        Console.WriteLine("\nDetails of each person:");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine("Person {0}: Height = {1} cm, Weight = {2} kg, BMI = {3}, Status = {4}", i+1, personData[i][0]*100, personData[i][1], personData[i][2], weightStatus[i]);
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
