using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Taking user input to enter the first number
                Console.WriteLine("Enter First number");
                int num1 = Int32.Parse(Console.ReadLine());

                // Taking user input to enter the second number
                Console.WriteLine("Enter Second number");
                int num2 = Int32.Parse(Console.ReadLine());

                // Performing division operation
                int result = num1 / num2;
                Console.WriteLine("Result is :" + result);
            }
            catch (DivideByZeroException)
            {
                // Handle the divide by zero exception
                Console.WriteLine("Division by Zero is not possible");
            }
            catch (FormatException ex)
            {
                // Handle other Format exceptions
                Console.WriteLine("User enters a non-numeric value: " + ex.Message);
            }

            finally
            {
                // Finally block execution
               Console.WriteLine("Operation completed ");
            }
        }
    }
}