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
    class Student
    {
        // Set name as private
        private string name;
         
        // Defining constructor 
        public Student(string name)
        {
            this.name = name;
        }
        
        // Displaying the name of the student
        public void Display()
        {
            Console.WriteLine("Student Name: " + name);
        }
    }
    
    class ReflectionConstructorExample
    {
        static void Main()
        {
            // Creating typeof student
            Type type = typeof(Student);
            
            // Access Constructor 
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string) });
            
            // Invoking the constructor without new keyword
            Student student = (Student)constructor.Invoke(new object[] { "Alice" });
            
            // Displaying the student name
            student.Display();
        }
    }
}