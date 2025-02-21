using System;

namespace CustomExceptionHandling
{
    // Custom exception class
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }

    class Program
    {
        // Method to validate age
        static void ValidateAge(int age)
        {
            if (age < 18)
            {
                // Throw custom exception if age is below 18
                throw new InvalidAgeException("Age must be 18 or above");
            }
            Console.WriteLine("Access granted!");
        }

        static void Main(string[] args)
        {
            try
            {
                // Taking user input for age
                Console.WriteLine("Enter your age:");
                int age = Int32.Parse(Console.ReadLine());

                // Validate the entered age
                ValidateAge(age);
            }
            catch (InvalidAgeException ex)
            {
                // Catch and display custom exception message
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                // Handle invalid number format
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
    }
}