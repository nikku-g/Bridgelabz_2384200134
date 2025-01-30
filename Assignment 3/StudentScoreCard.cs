using System;

class StudentScoreCard
{
    // Method to generate random 2-digit scores for Physics, Chemistry, and Math
    static int[,] GenerateRandomScores(int numStudents)
    {
        Random rand = new Random();
        int[,] scores = new int[numStudents, 3]; // 2D array: [0] = Physics, [1] = Chemistry, [2] = Math

        for (int i = 0; i < numStudents; i++)
        {
            // Random scores for Physics, Chemistry, and Math (2-digit numbers between 50 and 99)
            scores[i, 0] = rand.Next(50, 100); // Physics score
            scores[i, 1] = rand.Next(50, 100); // Chemistry score
            scores[i, 2] = rand.Next(50, 100); // Math score
        }

        return scores;
    }

    // Method to calculate total, average, and percentage for each student
    static double[,] CalculateScores(int[,] scores, int numStudents)
    {
        double[,] results = new double[numStudents, 4]; // [0] = total, [1] = average, [2] = percentage

        for (int i = 0; i < numStudents; i++)
        {
            // Calculate total
            double total = scores[i, 0] + scores[i, 1] + scores[i, 2];

            // Calculate average
            double average = total / 3;

            // Calculate percentage
            double percentage = (total / 300) * 100;

            // Store total, average, and percentage in the results array
            results[i, 0] = total;
            results[i, 1] = Math.Round(average, 2); // Round to 2 decimal places
            results[i, 2] = Math.Round(percentage, 2); // Round to 2 decimal places
        }

        return results;
    }

    // Method to display the scorecard in a tabular format
    static void DisplayScorecard(int[,] scores, double[,] results, int numStudents)
    {
        Console.WriteLine("\nScorecard for Students:");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("Student | Physics | Chemistry | Math | Total | Average | Percentage");
        Console.WriteLine("--------------------------------------------------------------------------------");

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"{i + 1,7} | {scores[i, 0],7} | {scores[i, 1],8} | {scores[i, 2],5} | {results[i, 0],5} | {results[i, 1],7} | {results[i, 2],10}%");
        }

        Console.WriteLine("--------------------------------------------------------------------------------");
    }

    static void Main()
    {
        // Take the number of students as input
        Console.Write("Enter the number of students: ");
        int numStudents = Convert.ToInt32(Console.ReadLine());

        // Generate random scores for all students
        int[,] scores = GenerateRandomScores(numStudents);

        // Calculate total, average, and percentage for each student
        double[,] results = CalculateScores(scores, numStudents);

        // Display the scorecard
        DisplayScorecard(scores, results, numStudents);
    }
}
