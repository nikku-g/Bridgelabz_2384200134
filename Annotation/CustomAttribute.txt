using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class TaskInfoAttribute : Attribute
{
    public int Priority { get; }
    public string AssignedTo { get; }

    public TaskInfoAttribute(int priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// Step 2: Apply the custom attribute to a method
class TaskManager
{
    [TaskInfo(1, "Alice")]
    public void CompleteTask()
    {
        Console.WriteLine("Task is being completed.");
    }
}

// Step 3: Retrieve attribute details using Reflection
class Program
{
    static void Main()
    {
        Type type = typeof(TaskManager);
        MethodInfo method = type.GetMethod("CompleteTask");

        if (method != null)
        {
            var attribute = (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));
            if (attribute != null)
            {
                Console.WriteLine($"Task Info: Priority = {attribute.Priority}, Assigned To = {attribute.AssignedTo}");
            }
        }
    }
}