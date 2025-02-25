using System;
using System.Reflection;

// Step 1: Define a Todo attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }

    public string Priority { get; }

    public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// Step 2: Apply Todo attribute to multiple methods
public class ProjectModule
{
    [Todo("Implement authentication", "Alice", "HIGH")]
    [Todo("Fix session timeout issue", "Bob", "MEDIUM")]
    public void UserLogin()
    {
        Console.WriteLine("User login method...");
    }

    [Todo("Optimize database queries", "Charlie")]
    public void FetchData()
    {
        Console.WriteLine("Fetching data...");
    }

    [Todo("Refactor error handling", "Dave", "LOW")]
    public void ProcessRequest()
    {
        Console.WriteLine("Processing request...");
    }
}

class Program
{
    static void Main()
    {
        // Step 3: Retrieve and print all Todo attributes using Reflection
        Type type = typeof(ProjectModule);
        MethodInfo[] methods = type.GetMethods();

        Console.WriteLine("Pending Tasks:");
        foreach (MethodInfo method in methods)
        {
            var todos = (TodoAttribute[])method.GetCustomAttributes(typeof(TodoAttribute), false);
            foreach (var todo in todos)
            {
                Console.WriteLine($"- Method: {method.Name}");
                Console.WriteLine($"  Task: {todo.Task}");
                Console.WriteLine($"  Assigned To: {todo.AssignedTo}");
                Console.WriteLine($"  Priority: {todo.Priority}\n");
            }
        }
    }
}