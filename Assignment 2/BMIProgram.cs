using System;

class BMIProgram {
	public static void Main()
    {
        // Input weight and height from the user
        Console.Write("Enter weight in kilograms (kg): ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter height in centimeters (cm): ");
        double heightInCm = double.Parse(Console.ReadLine());

        // Convert height to meters
        double heightInMeters = heightInCm / 100;

        // Call the BMI calculation method
        double bmi = CalculateBMI(weight, heightInMeters);

        // Display the BMI and weight status
        Console.WriteLine("\nBMI: {0}", bmi);
        Console.WriteLine("Weight Status: {0}", GetWeightStatus(bmi));
    }

    // Method to calculate BMI
    static double CalculateBMI(double weight, double height)
    {
        return weight / (height * height);  // BMI formula: weight / (height^2)
    }

    // Method to determine the weight status based on BMI
    static string GetWeightStatus(double bmi)
    {
        if (bmi <= 18.4)
        {
            return "Underweight";
        }
        else if (bmi >= 18.5 && bmi < 24.9)
        {
            return "Normal weight";
        }
        else if (bmi >= 25 && bmi < 39.9)
        {
            return "Overweight";
        }
        else
        {
            return "Obese";
        }
    }
}