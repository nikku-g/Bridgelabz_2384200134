using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    class Program
    {
        // Suppress warnings for using non-generic ArrayList
#pragma warning disable CS0618 // Suppresses obsolete warnings
#pragma warning disable CS8602 // Suppresses possible null reference warnings
        static void Main()
        {
            ArrayList list = new ArrayList();
            list.Add(10);        
            list.Add("Hello");   
            list.Add(3.14);      

            Console.WriteLine("ArrayList contents:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

#pragma warning restore CS0618 // Restore warning about obsolete features
#pragma warning restore CS8602 // Restore warning about null references
        }
    }
}