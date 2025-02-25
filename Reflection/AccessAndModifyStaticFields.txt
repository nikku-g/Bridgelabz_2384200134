using System;
using System.Reflection;

public class Configuration
{
    // Declaring a private static field
    private static string API_KEY = "DefaultKey";
}

class Program
{
    static void Main()
    {
        Configuration config = new Configuration();
        Type type = config.GetType();

        // Accessing private field
        FieldInfo field = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        // Get field value
        Console.WriteLine("Old Value: " + field.GetValue(config));

        // Modify field value
        field.SetValue(config, "SecretKey");
        Console.WriteLine("New Value: " + field.GetValue(config));


    }
}