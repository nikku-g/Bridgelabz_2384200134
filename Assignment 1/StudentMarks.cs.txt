using System;

class StudentMarks
{
    public static void Main(string[] args)
    {
        // Take input for the number of students
        Console.Write("Enter the number of students: ");
		int numberOfStudents = Convert.ToInt32(Console.ReadLine());
		if(numberOfStudents < 1 || numberOfStudents > int.MaxValue) {
			Console.Error.WriteLine("Please enter a valid positive integer.");
			Environment.Exit(0);
		}

        // Define arrays to store marks, percentages, and grades of students
		int[] physics = new int[numberOfStudents];
		int[] chemistry = new int[numberOfStudents];
		int[] maths = new int[numberOfStudents];

        double[] percentages = new double[numberOfStudents];
        string[] grades = new string[numberOfStudents];

        // Take input for marks of each student
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine("Enter marks for student {0}:", i+1);

            physics[0] = GetValidInput("Enter valid Physics marks (0-100): ", 0, 100);
            chemistry[0] = GetValidInput("Enter valid Chemistry marks (0-100): ", 0, 100);
            maths[0] = GetValidInput("Enter valid Maths marks (0-100): ", 0, 100);
        }

        // Calculate percentage and grade for each student
        for (int i = 0; i < numberOfStudents; i++)
        {
            int totalMarks = physics[0] + chemistry[0] + maths[0];
            percentages[i] = (double)totalMarks / 3;
            grades[i] = DetermineGrade(percentages[i]);
        }

        // Display marks, percentages, and grades of each student
        Console.WriteLine("\nDetails of each student:");
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine("Student {0}: Physics = {1}, Chemistry = {2}, Maths = {3}, Percentage = {4}%, Grade = {5}", i+1, physics[0], chemistry[0], maths[0], percentages[i], grades[i]);
        }
    }

    // Method to determine grade based on percentage
    static string DetermineGrade(double percentage)
    {
        if (percentage >= 80)
        {
            return "A - (Level 4, above agency-normalized standards)";
        }
        else if (percentage >= 70 && percentage <= 79)
        {
            return "B - (Level 3, at agency-normalized standards)";
        }
        else if (percentage >= 60 && percentage <= 69)
        {
            return "C - (Level 2, below but approaching agency-normalized standards)";
        }
        else if (percentage >= 50 && percentage <= 59)
        {
            return "D - (Level 1, well below agency-normalized standards)";
        }
        else if (percentage >= 40 && percentage <= 49)
        {
            return "F - (Level 1-, too below agency-normalized standards)";
        }
		else
		{
			return "R - (Remedial standards)";
		}
    }

    // Method to get valid integer input
    static int GetValidInput(string errorMessage, int min, int max)
    {
        int input;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
            {
                return input;
            }
            Console.Write(errorMessage);
        }
    }
}
