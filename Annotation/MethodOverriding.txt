using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class Animal
    {
        // Defines a method in the parent class
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes sound");
        }
    }

    class Dog : Animal
    {
        // Override the method in the child class
        public override void MakeSound()
        {
            Console.WriteLine("Animal makes sound");
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            // Instantiate Dog and call MakeSound()
            Animal dog = new Dog();
            dog.MakeSound();
        }
    }

}