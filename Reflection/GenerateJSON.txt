using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public static class ObjectSerializer
{
    public static string ToJson(object obj)
    {
        if (obj == null) return "null";
        
        Type type = obj.GetType();
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];
            object value = field.GetValue(obj);
            
            sb.AppendFormat("\"{0}\": \"{1}\"", field.Name, value);
            
            if (i < fields.Length - 1)
            {
                sb.Append(", ");
            }
        }
        
        sb.Append("}");
        return sb.ToString();
    }
}

// Example usage
public class Person
{
    public string Name;
    private int Age;
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Alice" };
        string json = ObjectSerializer.ToJson(person);
        Console.WriteLine(json); 
    }
}