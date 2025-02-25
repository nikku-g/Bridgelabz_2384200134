using System;
using System.Reflection;

// Step 1: Define a BugReport attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description { get; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// Step 2: Apply BugReport multiple times to a method
public class SampleClass
{
    [BugReport("Bug in data processing logic.")]
    [BugReport("Edge case for negative numbers not handled.")]
    public void ProcessData()
    {
        Console.WriteLine("Processing data...");
    }
}

class Program
{
    static void Main()
    {
        // Step 3: Retrieve and print all bug reports
        MethodInfo methodInfo = typeof(SampleClass).GetMethod("ProcessData");

        if (methodInfo != null)
        {
            var bugReports = (BugReportAttribute[])methodInfo.GetCustomAttributes(typeof(BugReportAttribute), false);

            Console.WriteLine("Bug Reports for method 'ProcessData':");
            foreach (var bug in bugReports)
            {
                Console.WriteLine($"- {bug.Description}");
            }
        }
    }
}