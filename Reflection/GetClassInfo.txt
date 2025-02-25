using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Taking user input for classname
            Console.Write("Enter the class name: ");
            string className = Console.ReadLine();

            // Get type
            Type type = Type.GetType(className);
            if (type == null)
            {
                Console.WriteLine("Class not found. Make sure to provide the full namespace and class name.");
                return;
            }

            Console.WriteLine($"\nClass: {type.FullName}");

            // Display Fields
            Console.WriteLine("\nFields:");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var field in fields)
            {
                Console.WriteLine($"  {field.FieldType} {field.Name}");
            }

            // Display Methods
            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                Console.WriteLine($"  {method.ReturnType} {method.Name}");
            }

            // Display Constructors
            Console.WriteLine("\nConstructors:");
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"  {constructor.Name}");
            }
        }
    }
}