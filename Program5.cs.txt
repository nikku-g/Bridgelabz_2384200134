using System;
using System.Diagnostics;

class FibonacciComparison
{
    static void Main()
    {
        int N = 30;

        Stopwatch sw = Stopwatch.StartNew();
        int recursiveResult = FibonacciRecursive(N);
        sw.Stop();
        Console.WriteLine($"Recursive: {sw.ElapsedMilliseconds} ms, Result: {recursiveResult}");

        sw.Restart();
        int iterativeResult = FibonacciIterative(N);
        sw.Stop();
        Console.WriteLine($"Iterative: {sw.ElapsedMilliseconds} ms, Result: {iterativeResult}");
        Console.ReadLine();
    }

    static int FibonacciRecursive(int n)
    {
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static int FibonacciIterative(int n)
    {
        if (n <= 1) return n;
        int a = 0, b = 1, sum;
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }
}
