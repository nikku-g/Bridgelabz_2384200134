using System;
using System.Reflection;

// Step 1: Define the RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method)]
public class RoleAllowed : Attribute
{
    public string Role { get; }

    public RoleAllowed(string role)
    {
        Role = role;
    }
}
// Step 2: Simulate a system with restricted methods
public class SecureSystem
{
    [RoleAllowed("ADMIN")]
    public void AdminTask()
    {
        Console.WriteLine("Admin task executed successfully.");
    }

    [RoleAllowed("USER")]
    public void UserTask()
    {
        Console.WriteLine("User task executed successfully.");
    }
}
// Step 3: Access control logic
class Program
{
    static void Main()
    {
        SecureSystem system = new SecureSystem();
        string currentUserRole = "USER"; // Change this to "ADMIN" to allow access

        AttemptMethodExecution(system, "AdminTask", currentUserRole);
        AttemptMethodExecution(system, "UserTask", currentUserRole);
    }

    static void AttemptMethodExecution(object obj, string methodName, string userRole)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        if (method != null)
        {
            var roleAttr = (RoleAllowed)Attribute.GetCustomAttribute(method, typeof(RoleAllowed));
            if (roleAttr != null)
            {
                if (roleAttr.Role == userRole)
                {
                    method.Invoke(obj, null);
                }
                else
                {
                    Console.WriteLine($"Access Denied! {userRole} is not allowed to execute {methodName}.");
                }
            }
        }
    }
}