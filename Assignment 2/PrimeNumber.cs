using System;

class PrimeNumber {
	public static void Main()
    {
        Console.Write("Enter a number to check if it is a prime number: ");
        int number = int.Parse(Console.ReadLine());

        if (number <= 1)
        {
            Console.WriteLine("{0} is not a prime number (Prime numbers are greater than 1).", number);
            return;
        }

        // Call the IsPrime method
        bool isPrime = IsPrime(number);

        // Display the result
        if (isPrime)
        {
            Console.WriteLine("{0} is a prime number.", number);
        }
        else
        {
            Console.WriteLine("{0} is not a prime number.", number);
        }
    }

    // Method to check if a number is a prime number
    static bool IsPrime(int number)
    {
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false; // Number is divisible by another number, not prime
            }
        }
        return true; // Number is prime
    }
}