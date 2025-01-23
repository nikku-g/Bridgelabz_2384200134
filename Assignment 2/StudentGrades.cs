using System;

class StudentGrades {
	public static void Main()
    {
        // Input marks for three subjects
        double physics = GetMarks("Physics");
        double chemistry = GetMarks("Chemistry");
        double maths = GetMarks("Mathematics");

        // Calculate total and average
        double total = physics + chemistry + maths;
        double average = CalculateAverage(total, 3);

        // Display results
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine("Total Marks: {0}/300", total);
        Console.WriteLine("Average Marks: {0}", average);
        Console.WriteLine("Grade and Remarks: {0}", GetGradeAndRemarks(average));
    }

    // Method to input marks for a specific subject
    static double GetMarks(string subject)
    {
        Console.Write("Enter marks for {0}: ", subject);
        return double.Parse(Console.ReadLine());
    }

    // Method to calculate the average
    static double CalculateAverage(double total, int numberOfSubjects)
    {
        return total / numberOfSubjects;
    }

    // Method to determine grade and remarks based on average marks
    static string GetGradeAndRemarks(double average)
    {
        if (average >= 80)
        {
            return "A - (Level 4, above agency-normalized standards)";
        }
        else if (average >= 70 && average <= 79)
        {
            return "B - (Level 3, at agency-normalized standards)";
        }
        else if (average >= 60 && average <= 69)
        {
            return "C - (Level 2, below but approaching agency-normalized standards)";
        }
        else if (average >= 50 && average <= 59)
        {
            return "D - (Level 1, well below agency-normalized standards)";
        }
        else if (average >= 40 && average <= 49)
        {
            return "F - (Level 1-, too below agency-normalized standards)";
        }
		else
		{
			return "R - (Remedial standards)";
		}
    }
}