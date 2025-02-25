using System;
using System.Diagnostics;
using System.Reflection;

// Step 1: Define the LogExecutionTime attribute
[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTime : Attribute { }

// Step 2: Apply LogExecutionTime attribute to methods
public class PerformanceTest
{
    [LogExecutionTime]
    public void FastMethod()
    {
        Console.WriteLine("Executing FastMethod...");
        System.Threading.Thread.Sleep(100); // Simulating work
    }

    [LogExecutionTime]
    public void SlowMethod()
    {
        Console.WriteLine("Executing SlowMethod...");
        System.Threading.Thread.Sleep(500); // Simulating longer work
    }
}

class Program
{
    static void Main()
    {
        PerformanceTest test = new PerformanceTest();
        MeasureExecutionTime(test, "FastMethod");
        MeasureExecutionTime(test, "SlowMethod");
    }

    // Step 3: Measure and print execution time using reflection
    static void MeasureExecutionTime(object obj, string methodName)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        if (method != null && method.GetCustomAttribute(typeof(LogExecutionTime)) != null)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            method.Invoke(obj, null); // Invoke method dynamically
            stopwatch.Stop();

            Console.WriteLine($"Execution Time for {methodName}: {stopwatch.ElapsedMilliseconds} ms\n");
        }
    }
}