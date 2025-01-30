using System;

class ReverseDigits
{
    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
		
		if(number < 0 || number > int.MaxValue) {
			Console.Error.WriteLine("Invalid input. Please enter a valid number.");
			Environment.Exit(0);
		}
		
        int[] digits = GetDigits(number);
        int[] reversedDigits = ReverseArray(digits);

        Console.WriteLine("Original Digits:");
        DisplayArray(digits);

        Console.WriteLine("Reversed Digits:");
        DisplayArray(reversedDigits);
    }
	
	// Extracts digits of a number and returns them as an array.
    static int[] GetDigits(long number)
    {
		// Convert the absolute value of the number to a string to handle negative input.
        string numberStr = Math.Abs(number).ToString();
        int[] digits = new int[numberStr.Length];

        for (int i = 0; i < numberStr.Length; i++)
        {
            digits[i] = int.Parse(numberStr[i].ToString());
        }

        return digits;
    }

	// Reverses the elements of an array and returns the reversed array.
    static int[] ReverseArray(int[] array)
    {
        int[] reversed = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            reversed[i] = array[array.Length - 1 - i];
        }
        return reversed;
    }

	// Displays the elements of an array separated by spaces.
    static void DisplayArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
