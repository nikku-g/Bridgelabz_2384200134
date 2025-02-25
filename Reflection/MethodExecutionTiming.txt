using System;
using System.Diagnostics;
using System.Reflection;

public class MethodTimer
{
    public static void MeasureExecutionTime<T>(string methodName, params object[] parameters)
    {
        Type type = typeof(T);
        // Retrieve method information using reflection
        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        
        if (method == null)
        {
            Console.WriteLine("Method not found.");
            return;
        }
        
        // Create an instance of the class if the method is not static
        object instance = method.IsStatic ? null : Activator.CreateInstance(type);
        
        // Start measuring execution time
        Stopwatch stopwatch = Stopwatch.StartNew();
        
        // Invoke the method dynamically
        method.Invoke(instance, parameters);
        
        // Stop the timer
        stopwatch.Stop();
        Console.WriteLine($"Execution Time for {methodName}: {stopwatch.ElapsedMilliseconds} ms");
    }
}

// Example Usage
public class SampleClass
{
    /// A fast-executing method.
    public void FastMethod() => Console.WriteLine("Fast Method Executed");

    /// A slow-executing method that simulates delay.

    public void SlowMethod()
    {
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Slow Method Executed");
    }
}

class Program
{
    static void Main()
    {
        // Measure execution time of methods in SampleClass
        MethodTimer.MeasureExecutionTime<SampleClass>("FastMethod");
        MethodTimer.MeasureExecutionTime<SampleClass>("SlowMethod");
    }
}