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
    public class Person
    {
        // Declaring age as private
        private int age = 22;
    }
        
    public class Program
    {
        public static void Main(string[] args)
        { 
            // Creating an instance of person class
            Person person = new Person();
            Type type = person.GetType();
                
            // Access private field
            FieldInfo field = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

            // Get field value
            Console.WriteLine("Old Value: " + field.GetValue(person));
            // Modify field value
            field.SetValue(person, 25);
            Console.WriteLine("New Value: " + field.GetValue(person));
        }
    }
}