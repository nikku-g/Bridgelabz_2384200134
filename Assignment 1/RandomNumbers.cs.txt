using System;

public class RandomNumberProcessor
{
    // Method to generate an array of 4-digit random numbers
    public int[] Generate4DigitRandomArray(int size)
    {
        Random random = new Random();
        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(1000, 10000); // Generate random 4-digit numbers
        }

        return numbers;
    }

    // Method to find the average, minimum, and maximum values of an array
    public double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        double average = (double)sum / numbers.Length;
        return new double[] { average, min, max };
    }
}

class RandomNumbers
{
    public static void Main(string[] args)
    {
        RandomNumberProcessor processor = new RandomNumberProcessor();

        // Generate an array of 5 random 4-digit numbers
        int[] randomNumbers = processor.Generate4DigitRandomArray(5);

        // Display the generated numbers
        Console.WriteLine("Generated 4-digit random numbers:");
        foreach (int num in randomNumbers)
        {
            Console.WriteLine(num);
        }

        // Find and display the average, minimum, and maximum values
        double[] results = processor.FindAverageMinMax(randomNumbers);
        Console.WriteLine("\nAverage: {0}", results[0].ToString("F2"));
        Console.WriteLine("Minimum: {0}", results[1].ToString("F2"));
        Console.WriteLine("Maximum: {0}", results[2].ToString("F2"));
    }
}
