using System;
using System.Reflection;

// Define the custom attribute
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class AuthorAttribute : Attribute
{
    public string Name { get; }
    
    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

// Apply the custom attribute to a class
[Author("John Doe")]
public class SampleClass
{
    public void DisplayMessage()
    {
        Console.WriteLine("Hello from SampleClass!");
    }
}

class Program
{
    static void Main()
    {
        // Get the type of SampleClass
        Type type = typeof(SampleClass);
        
        // Retrieve the Author attribute
        AuthorAttribute attribute = (AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));
        
        // Display the attribute value
        if (attribute != null)
        {
            Console.WriteLine($"Author: {attribute.Name}");
        }
        else
        {
            Console.WriteLine("No Author attribute found.");
        }
    }
}