using System;
using System.Collections.Generic;
using System.Reflection;

public static class ObjectBuilder
{
    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties) where T : new()
    {
        if (clazz == null) throw new ArgumentNullException(nameof(clazz));
        if (properties == null) throw new ArgumentNullException(nameof(properties));
        
        T obj = new T(); // Create a new instance of T
        
        foreach (var kvp in properties)
        {
            // Find the field in the specified class using reflection
            FieldInfo field = clazz.GetField(kvp.Key, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            // If field is found and the value is assignable, set the field value
            if (field != null && field.FieldType.IsAssignableFrom(kvp.Value.GetType()))
            {
                field.SetValue(obj, kvp.Value);
            }
        }
        
        return obj;
    }
}

// Example class with public and private fields
public class Person
{
    public string Name; // Public field
    private int Age; // Private field
}

class Program
{
    static void Main()
    {
        // Dictionary containing field names and corresponding values
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "Name", "Alice" },
            { "Age", 25 }
        };

        // Convert dictionary to Person object
        Person person = ObjectBuilder.ToObject<Person>(typeof(Person), data);
        
        // Print the public field value
        Console.WriteLine(person.Name); 
    }
}