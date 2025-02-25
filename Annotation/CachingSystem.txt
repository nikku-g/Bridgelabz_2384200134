using System;
using System.Collections.Generic;
using System.Reflection;

// Step 1: Define the CacheResult attribute
[AttributeUsage(AttributeTargets.Method)]
public class CacheResult : Attribute { }

// Step 2: Implement a caching mechanism
public class Computation
{
    private static Dictionary<string, object> cache = new Dictionary<string, object>();

    [CacheResult]
    public int ExpensiveCalculation(int number)
    {
        string cacheKey = $"{nameof(ExpensiveCalculation)}({number})";

        if (cache.ContainsKey(cacheKey))
        {
            Console.WriteLine($"Returning cached result for {number}");
            return (int)cache[cacheKey];
        }

        Console.WriteLine($"Computing result for {number}...");
        int result = number * number; // Simulating an expensive operation
        cache[cacheKey] = result;
        return result;
    }
}

// Step 3: Test caching behavior
class Program
{
    static void Main()
    {
        Computation comp = new Computation();

        // First-time calculations
        Console.WriteLine($"Result: {comp.ExpensiveCalculation(5)}");
        Console.WriteLine($"Result: {comp.ExpensiveCalculation(10)}");

        // Cached results (no recomputation)
        Console.WriteLine($"Result: {comp.ExpensiveCalculation(5)}");
        Console.WriteLine($"Result: {comp.ExpensiveCalculation(10)}");
    }
}