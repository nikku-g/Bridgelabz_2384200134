using System;

class Largest2
{
    public static void Main()
    {
        // Take user input for the number
        Console.Write("Enter a number: ");
		int number = Convert.ToInt32(Console.ReadLine());
		if(number < 0 || number > int.MaxValue) {
			Console.Error.WriteLine("Please enter a valid positive integer.");
			Environment.Exit(0);
		}

        // Define an array to store the digits and related variables
        int maxDigit = 5;
        int[] digits = new int[maxDigit];
        int index = 0; // Reflects the current array index

        // Extract digits from the number and store them in the array
        while (number != 0)
        {
            if (index == maxDigit)
            {
                // Increase the size of the array dynamically
                maxDigit += 10;
                int[] temp = new int[maxDigit]; // Created temperary array with increased size
                for (int i = 0; i < digits.Length; i++)
                {
                    temp[i] = digits[i];
                }
                digits = temp;
            }

            digits[index] = number % 10; // Get the last digit
            number /= 10; // Remove the last digit
            index++; // Increment the index
        }

        // Initialize variables to find the largest and second-largest digits
        int largest = 0, secondLargest = 0;

        // Loop through the array to find the largest and second-largest digits
        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest; // Update second largest
                largest = digits[i]; // Update largest
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i]; // Update second largest
            }
        }

        // Display the largest and second-largest digits
        Console.WriteLine("The largest digit is: {0}", largest);
        Console.WriteLine("The second largest digit is: {0}", secondLargest);
    }
}
