using System;
using System.Collections.Generic;

class GenerateBinaryNumbers
{
    // Method to generate first N binary numbers using a queue
    public static List<string> GenerateBinaryNumbersUsingQueue(int N)
    {
        List<string> binaryNumbers = new List<string>();

        // Create a queue to store the binary numbers
        Queue<string> queue = new Queue<string>();

        // Start by enqueuing the first binary number "1"
        queue.Enqueue("1");

        // Generate binary numbers up to N
        for (int i = 0; i < N; i++)
        {
            // Dequeue the front element (the current binary number)
            string currentBinary = queue.Dequeue();
            // Add the current binary number to the result list
            binaryNumbers.Add(currentBinary);

            // Generate the next two binary numbers and enqueue them
            queue.Enqueue(currentBinary + "0");
            queue.Enqueue(currentBinary + "1");
        }

        return binaryNumbers;
    }

    static void Main()
    {
        // Input: N (the number of binary numbers to generate)
        int N = 5;

        // Generate the binary numbers using the queue
        List<string> binaryNumbers = GenerateBinaryNumbersUsingQueue(N);

        // Output the generated binary numbers
        Console.WriteLine("The first " + N + " binary numbers are:");
        foreach (string binary in binaryNumbers)
        {
            Console.WriteLine(binary);
        }
    }
}
