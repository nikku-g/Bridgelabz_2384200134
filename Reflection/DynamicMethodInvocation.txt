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
    public class MathOperations
    {
        // Declaring method as public
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
    }

    public class Operations
    {
        public static void Main(String[] args)
        {
            // Creating an object of class
            MathOperations mathOps = new MathOperations();
            Type type = typeof(MathOperations);

            // Take user input for method name
            Console.WriteLine("Enter method name (Add, Subtract, Multiply):");
            string methodName = Console.ReadLine();

            // Take user input for first number
            Console.WriteLine("Enter first number:");
            int num1 = int.Parse(Console.ReadLine());
            
            // Take user input for second number
            Console.WriteLine("Enter second number:");
            int num2 = int.Parse(Console.ReadLine());

            MethodInfo method = type.GetMethod(methodName);
            if (method != null)
            {
                object result = method.Invoke(mathOps, new object[] { num1, num2 });
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                Console.WriteLine("Invalid method name.");
            }
        }
    }

}