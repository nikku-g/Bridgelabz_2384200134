using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProblems
{
    public class Calculator
    {
        // Declaring method as private
        private int Multiply(int a, int b) => a * b;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Creating an instance of calculator class
            Calculator calc = new Calculator();
            Type type = calc.GetType();

            // Access private method
            MethodInfo method = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);

            // Invoke the method
            int result = (int)method.Invoke(calc, new object[] { 5, 10 });

            // Display the result
            Console.WriteLine("Multiplication Result: " + result);
        }

    }
}