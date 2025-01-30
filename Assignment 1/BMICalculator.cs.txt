using System;

public class BMICalculator
{
    // Method to calculate BMI
    public double CalculateBMI(double weight, double heightInCm)
    {
        double heightInMeters = heightInCm / 100; // Convert height from cm to meters
        return weight / (heightInMeters * heightInMeters); // BMI formula: weight / (height^2)
    }

    // Method to determine BMI status
    public string DetermineBMIStatus(double bmi)
    {
        if (bmi < 18.5)
            return "Underweight";
        else if (bmi >= 18.5 && bmi < 24.9)
            return "Normal weight";
        else if (bmi >= 25 && bmi < 29.9)
            return "Overweight";
        else
            return "Obese";
    }
}

class BMI
{
    public static void Main(string[] args)
    {
        double[,] data = new double[10, 3]; // Array to store weight, height, and BMI
        string[] bmiStatus = new string[10]; // Array to store BMI status
        BMICalculator calculator = new BMICalculator();

        Console.WriteLine("Enter weight (in kg) and height (in cm) for 10 team members:");

        // Input weight and height for each person
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Person {0} - Weight (kg): ", i+1);
            while (!double.TryParse(Console.ReadLine(), out data[i, 0]) || data[i, 0] <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for weight.");
                Console.Write("Person {0} - Weight (kg): ", i+1);
            }

            Console.Write("Person {0} - Height (cm): ", i+1);
            while (!double.TryParse(Console.ReadLine(), out data[i, 1]) || data[i, 1] <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for height.");
                Console.Write("Person {0} - Height (cm): ", i+1);
            }

            // Calculate BMI and store it
            data[i, 2] = calculator.CalculateBMI(data[i, 0], data[i, 1]);

            // Determine BMI status
            bmiStatus[i] = calculator.DetermineBMIStatus(data[i, 2]);
        }

        // Display the results
        Console.WriteLine("\nTeam Members' BMI Analysis:");
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Person\tWeight (kg)\tHeight (cm)\tBMI\t\tStatus");
        Console.WriteLine("-------------------------------------------------------");
        for (int i = 0; i < 10; i++)
        {
		Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t{4}", i+1, data[i, 0].ToString("F2"), data[i, 1].ToString("F2"), data[i, 2].ToString("F2"), bmiStatus[i]);
        }
    }
}
